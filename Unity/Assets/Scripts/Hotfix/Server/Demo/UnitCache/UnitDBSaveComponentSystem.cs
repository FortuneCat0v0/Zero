using System;

namespace ET.Server
{
    [Invoke((long)SceneType.UnitCache)]
    public class AddToBytesInvoker_Cache : AInvokeHandler<AddToBytes>
    {
        public override void Handle(AddToBytes args)
        {
            Unit unit = args.Unit;
            unit?.GetComponent<UnitDBSaveComponent>().AddToBytes(args.Type, args.Bytes);
        }
    }

    [Invoke(TimerInvokeType.SaveChangeDBData)]
    public class UnitDBSaveComponentTimer : ATimer<UnitDBSaveComponent>
    {
        protected override void Run(UnitDBSaveComponent self)
        {
            try
            {
                self.SaveChange().Coroutine();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }

    [Event(SceneType.All)]
    public class UnitGetComponent_GetComponent : AEvent<Scene, UnitGetComponent>
    {
        protected override async ETTask Run(Scene scene, UnitGetComponent args)
        {
            Unit unit = args.Unit;
            Type type = args.Type;

            unit.GetComponent<UnitDBSaveComponent>()?.AddChange(type);

            if (unit.Components.ContainsKey(type.TypeHandle.Value.ToInt64()))
            {
                return;
            }

            UnitDBSaveComponent unitDBSaveComponent = unit.GetComponent<UnitDBSaveComponent>();
            if (unitDBSaveComponent == null)
            {
                return;
            }

            // Unit身上不存在需要挂载的组件，这个时候从字节数组容器中获取，并进行反序列化挂在Unit身上
            if (!unit.GetComponent<UnitDBSaveComponent>().Bytes.TryGetValue(type, out byte[] bs))
            {
                return;
            }

            // 延迟组件的反序列的时机，用到的时候才进行反序列化操作，抹平CPU消耗尖峰
            Entity t = MongoHelper.Deserialize(type, bs) as Entity;
            unit.AddComponent(t);

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(UnitDBSaveComponent))]
    [EntitySystemOf(typeof(UnitDBSaveComponent))]
    public static partial class UnitDBSaveComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UnitDBSaveComponent self)
        {
            // 正式上线 10~15分钟
            // self.Timer = self.Root().GetComponent<TimerComponent>()
            //         .NewRepeatedTimer(RandomGenerator.RandomNumber(10, 16) * 60 * 1000, TimerInvokeType.SaveChangeDBData, self);

            // 开发中 4秒
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(4 * 1000, TimerInvokeType.SaveChangeDBData, self);
        }

        [EntitySystem]
        private static void Destroy(this UnitDBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void AddToBytes(this UnitDBSaveComponent self, Type type, byte[] bytes)
        {
            self.Bytes[type] = bytes;
        }

        public static void AddChange(this UnitDBSaveComponent self, Type type)
        {
            self.EntityChangeTypeSet.Add(type);
        }

        public static async ETTask SaveChange(this UnitDBSaveComponent self)
        {
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Mailbox, self.GetParent<Unit>().InstanceId))
            {
                self.SaveChangeNoWait();
            }
        }

        public static void SaveChangeNoWait(this UnitDBSaveComponent self)
        {
            if (self.IsDisposed || self.Parent == null)
            {
                return;
            }

            if (self.Root() == null)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();

            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            if (self.EntityChangeTypeSet.Count <= 0)
            {
                return;
            }

            Other2UnitCache_AddOrUpdateUnit message = Other2UnitCache_AddOrUpdateUnit.Create();
            message.UnitId = unit.Id;
            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(unit.ToBson());

            foreach (var type in self.EntityChangeTypeSet)
            {
                Entity entity = unit.GetComponent(type);
                if (entity == null || entity.IsDisposed)
                {
                    continue;
                }

                Log.Debug("开始保存变化部分Entity数据：" + type.FullName);
                byte[] bytes = entity.ToBson();
                message.EntityTypes.Add(type.FullName);
                message.EntityBytes.Add(bytes);
                self.AddToBytes(type, bytes);
            }

            self.EntityChangeTypeSet.Clear();

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetOneBySceneType(unit.Zone(), SceneType.UnitCache);
            self.Root().GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message).Coroutine();
        }
    }
}