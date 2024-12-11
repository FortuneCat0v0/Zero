using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(GameObjectComponent))]
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
            if (self.GameObject != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.GameObject);
            }

            if (self.MountGameObject != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.MountGameObject);
            }
        }

        public static void UpdateRotation(this GameObjectComponent self, Quaternion quaternion)
        {
            if (self.MountGameObject != null)
            {
                self.MountGameObject.transform.rotation = quaternion;
                return;
            }

            if (self.GameObject != null)
            {
                self.GameObject.transform.rotation = quaternion;
            }
        }

        public static void UpdatePosition(this GameObjectComponent self, Vector3 vector)
        {
            if (self.MountGameObject != null)
            {
                self.MountGameObject.transform.position = vector;
                return;
            }

            if (self.GameObject != null)
            {
                self.GameObject.transform.position = vector;
            }
        }

        /// <summary>
        /// 骑上坐骑
        /// </summary>
        /// <param name="self"></param>
        public static void RideMount(this GameObjectComponent self, string name)
        {
            if (self.MountGameObject != null)
            {
                return;
            }

            self.MountGameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Scene(), AssetPathHelper.GetUnitPath(name));
            self.MountGameObject.transform.SetParent(self.Root().GetComponent<GlobalComponent>().UnitRoot);
            self.MountGameObject.transform.localPosition = self.GameObject.transform.localPosition;
            self.MountGameObject.transform.localRotation = self.GameObject.transform.localRotation;

            Transform point = self.MountGameObject.GetComponent<ReferenceCollector>().Get<GameObject>("Trans_HeadPos").transform;
            self.GameObject.transform.SetParent(point);
            self.GameObject.transform.localPosition = Vector3.zero;

            self.GetParent<Unit>().GetComponent<AnimationComponent>().UpdateAnimData(self.MountGameObject);

            // 处理动画
        }

        /// <summary>
        /// 骑下坐骑
        /// </summary>
        /// <param name="self"></param>
        public static void LeaveMount(this GameObjectComponent self)
        {
            if (self.MountGameObject == null)
            {
                return;
            }

            self.GameObject.transform.SetParent(self.Root().GetComponent<GlobalComponent>().UnitRoot);
            self.GameObject.transform.localPosition = self.MountGameObject.transform.localPosition;
            self.GameObject.transform.localRotation = self.MountGameObject.transform.localRotation;

            GameObjectPoolHelper.ReturnObjectToPool(self.MountGameObject);
            self.MountGameObject = null;

            // 处理动画
        }
    }
}