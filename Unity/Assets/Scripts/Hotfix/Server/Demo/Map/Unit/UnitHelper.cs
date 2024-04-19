using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(MoveComponent))]
    [FriendOf(typeof(NumericComponent))]
    public static partial class UnitHelper
    {
        public static UnitInfo CreateUnitInfo(Unit unit)
        {
            UnitInfo unitInfo = UnitInfo.Create();
            NumericComponent nc = unit.GetComponent<NumericComponent>();
            unitInfo.UnitId = unit.Id;
            unitInfo.ConfigId = unit.ConfigId;
            unitInfo.Type = (int)unit.Type();
            unitInfo.Position = unit.Position;
            unitInfo.Forward = unit.Forward;

            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            if (moveComponent != null)
            {
                if (!moveComponent.IsArrived())
                {
                    unitInfo.MoveInfo = MoveInfo.Create();
                    unitInfo.MoveInfo.Points.Add(unit.Position);
                    for (int i = moveComponent.N; i < moveComponent.Targets.Count; ++i)
                    {
                        float3 pos = moveComponent.Targets[i];
                        unitInfo.MoveInfo.Points.Add(pos);
                    }
                }
            }

            foreach ((int key, long value) in nc.NumericDic)
            {
                unitInfo.KV.Add(key, value);
            }

            return unitInfo;
        }

        // 获取看见unit的玩家，主要用于广播
        public static Dictionary<long, EntityRef<AOIEntity>> GetBeSeePlayers(this Unit self)
        {
            return self.GetComponent<AOIEntity>().GetBeSeePlayers();
        }

        /// <summary>
        /// 给Player添加GateMapComponent组件，并创建一个Map Scene赋值给GateMapComponent组件。从缓存服获取Unit挂载在Map Scene下，如果查询不到，
        /// 则创建一个Unit,并更新到UnitCache服上
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static async ETTask<(bool, Unit)> LoadUnit(Player player)
        {
            // 在Gate上动态创建一个Map Scene，把Unit从DB中加载放进来，然后传送到真正的Map中，这样登陆跟传送的逻辑就完全一样了
            GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
            gateMapComponent.Scene =
                    await GateMapFactory.Create(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");

            Unit unit = await UnitCacheHelper.GetUnitCache(gateMapComponent.Scene, player.Id);

            bool isNewUnit = unit == null;
            if (isNewUnit)
            {
                unit = UnitFactory.Create(gateMapComponent.Scene, player.Id, EUnitType.Player);

                List<Role> roles = await player.Root().GetComponent<DBManagerComponent>().GetZoneDB(player.Zone())
                        .Query<Role>(d => d.Id == player.Id);
                // unit.AddComponent(roleList[0]);

                UnitCacheHelper.AddOrUpdateUnitAllCache(unit);
            }

            return (isNewUnit, unit);
        }

        public static async ETTask InitUnit(Unit unit, bool isNew)
        {
            // unit.GetComponent<NumericComponent>().SetNoEvent(NumericType.MaxBagCapacity, 30);
            await ETTask.CompletedTask;
        }
    }
}