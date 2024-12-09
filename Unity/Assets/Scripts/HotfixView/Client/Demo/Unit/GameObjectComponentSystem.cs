using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(GameObjectComponent))]
    public static partial class GameObjectComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameObjectComponent self, string name)
        {
            GameObject gameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Scene(), AssetPathHelper.GetUnitPath(name));
            gameObject.transform.SetParent(self.Root().GetComponent<GlobalComponent>().UnitRoot);
            self.GameObject = gameObject;
        }

        [EntitySystem]
        private static void Destroy(this GameObjectComponent self)
        {
            GameObjectPoolHelper.ReturnObjectToPool(self.GameObject);
        }
    }
}