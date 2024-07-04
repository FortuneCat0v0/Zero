using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(TriggerColliderComponent))]
    [EntitySystemOf(typeof(TriggerColliderComponent))]
    public static partial class TriggerColliderComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TriggerColliderComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ColliderCallback colliderCallback = gameObject.GetComponent<ColliderCallback>();

            colliderCallback.OnTriggerEnterAction = self.OnTriggerEnter;
            colliderCallback.OnTriggerStayAction = self.OnTriggerStay;
            colliderCallback.OnTriggerExitAction = self.OnTriggerExit;
        }

        [EntitySystem]
        private static void Destroy(this TriggerColliderComponent self)
        {
            ColliderCallback colliderCallback = self.GameObject.GetComponent<ColliderCallback>();
            colliderCallback.OnTriggerEnterAction = null;
            colliderCallback.OnTriggerStayAction = null;
            colliderCallback.OnTriggerExitAction = null;
        }

        private static void OnTriggerEnter(this TriggerColliderComponent self, Collider collider)
        {
            GameObject go = collider.gameObject;
            if (go.tag.Equals("WorldItem"))
            {
                Log.Debug("碰撞的物体是" + go.name);
                // long unitId = go.name.id;
            }
        }

        private static void OnTriggerStay(this TriggerColliderComponent self, Collider collider)
        {
        }

        private static void OnTriggerExit(this TriggerColliderComponent self, Collider collider)
        {
            Log.Debug("退出了触发碰撞");
        }
    }
}