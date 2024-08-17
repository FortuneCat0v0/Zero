namespace ET.Server
{
    [FriendOf(typeof(CollisionListenerComponent))]
    [EntitySystemOf(typeof(CollisionListenerComponent))]
    public static partial class CollisionListenerComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CollisionListenerComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this CollisionListenerComponent self)
        {
        }

        [EntitySystem]
        private static void FixedUpdate(this CollisionListenerComponent self)
        {
            foreach (var tobeRemovedData in self.ToBeRemovedCollisionData)
            {
                self.CollisionRecorder.Remove(tobeRemovedData);
            }

            self.ToBeRemovedCollisionData.Clear();

            foreach (var cachedCollisionData in self.CollisionRecorder)
            {
                UnitComponent unitComponent = self.Root().GetComponent<UnitComponent>();
                Unit unitA = unitComponent.Get(cachedCollisionData.Item1);
                Unit unitB = unitComponent.Get(cachedCollisionData.Item2);

                if (unitA == null || unitB == null || unitA.IsDisposed || unitB.IsDisposed)
                {
                    // Id不分顺序，防止移除失败
                    self.ToBeRemovedCollisionData.Add((cachedCollisionData.Item1, cachedCollisionData.Item2));
                    self.ToBeRemovedCollisionData.Add((cachedCollisionData.Item2, cachedCollisionData.Item1));
                    continue;
                }

                CollisionHandlerDispatcherComponent.Instance.HandleCollisionSustain(unitA, unitB);
                CollisionHandlerDispatcherComponent.Instance.HandleCollisionSustain(unitB, unitA);
            }
        }
    }
}