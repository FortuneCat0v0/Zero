using System;

namespace ET.Server
{
    [FriendOf(typeof(ChatUnitComponent))]
    [EntitySystemOf(typeof(ChatUnitComponent))]
    public static partial class ChatUnitComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ChatUnitComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ChatUnitComponent self)
        {
            foreach (ChatUnit chatUnit in self.ChatUnitDict.Values)
            {
                chatUnit?.Dispose();
            }

            self.ChatUnitDict.Clear();
        }

        public static void Add(this ChatUnitComponent self, ChatUnit chatUnit)
        {
            if (self.ChatUnitDict.ContainsKey(chatUnit.Id))
            {
                Log.Error($"chatInfoUnit is exist! ： {chatUnit.Id}");
                return;
            }

            self.ChatUnitDict.Add(chatUnit.Id, chatUnit);
        }

        public static ChatUnit Get(this ChatUnitComponent self, long id)
        {
            self.ChatUnitDict.TryGetValue(id, out EntityRef<ChatUnit> entityRef);
            return entityRef;
        }

        public static void Remove(this ChatUnitComponent self, long id)
        {
            if (self.ChatUnitDict.Remove(id, out EntityRef<ChatUnit> entityRef))
            {
                ChatUnit chatUnit = entityRef;
                chatUnit?.Dispose();
            }
        }
    }
}