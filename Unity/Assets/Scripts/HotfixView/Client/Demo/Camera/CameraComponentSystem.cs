using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(CameraComponent))]
    [EntitySystemOf(typeof(CameraComponent))]
    public static partial class CameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CameraComponent self)
        {
            self.Camera = Camera.main;
        }

        [EntitySystem]
        private static void LateUpdate(this CameraComponent self)
        {
            if (self.UnitTransform == null)
            {
                self.UnitTransform = UnitHelper.GetMyUnitFromCurrentScene(self.Scene())?.GetComponent<GameObjectComponent>()?.Transform;
                if (self.UnitTransform == null)
                {
                    return;
                }
            }

            Vector3 pos = self.UnitTransform.position;
            self.Camera.transform.position = new Vector3(pos.x, pos.y + 7, pos.z - 5);
            self.Camera.transform.LookAt(self.UnitTransform);
        }
    }
}