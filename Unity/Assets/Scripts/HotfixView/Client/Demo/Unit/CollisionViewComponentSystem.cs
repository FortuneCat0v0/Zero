using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(CollisionViewComponent))]
    [EntitySystemOf(typeof(CollisionViewComponent))]
    public static partial class CollisionViewComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CollisionViewComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
        }

        public static void AddColloder(this CollisionViewComponent self, ColliderType colliderType, Vector2 vector2, float angle = 0)
        {
            switch (colliderType)
            {
                case ColliderType.Circle:
                    SphereCollider sphereCollider = self.GameObject.GetComponent<SphereCollider>();
                    if (sphereCollider == null)
                    {
                        sphereCollider = self.GameObject.AddComponent<SphereCollider>();
                    }

                    sphereCollider.isTrigger = true;
                    sphereCollider.radius = vector2.x;

                    break;
                case ColliderType.Box:
                    BoxCollider boxCollider = self.GameObject.GetComponent<BoxCollider>();
                    if (boxCollider == null)
                    {
                        boxCollider = self.GameObject.AddComponent<BoxCollider>();
                    }

                    boxCollider.isTrigger = true;
                    boxCollider.size = new Vector3(vector2.x, 1f, vector2.y);

                    break;
            }
        }
    }
}