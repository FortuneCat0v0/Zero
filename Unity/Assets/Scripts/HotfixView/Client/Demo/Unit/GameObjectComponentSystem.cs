namespace ET.Client
{
    [EntitySystemOf(typeof(GameObjectComponent))]
    public static partial class GameObjectComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameObjectComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this GameObjectComponent self)
        {
            if (self.UnitGo != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.UnitGo);
            }

            if (self.ModelGo != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.ModelGo);
            }
        }
    }
}