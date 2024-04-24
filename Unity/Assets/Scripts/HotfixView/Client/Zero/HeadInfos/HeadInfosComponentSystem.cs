using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(HeadInfosComponent))]
    [EntitySystemOf(typeof(HeadInfosComponent))]
    public static partial class HeadInfosComponentSystem
    {
        [EntitySystem]
        private static void Awake(this HeadInfosComponent self)
        {
        }

        [EntitySystem]
        private static void LateUpdate(this HeadInfosComponent self)
        {
            if (self.Transform == null)
            {
                return;
            }

            if (self.MainCameraTransform == null)
            {
                return;
            }

            self.Transform.forward = -self.MainCameraTransform.forward;
        }

        public static async ETTask Init(this HeadInfosComponent self, Transform parentTransform, float offset)
        {
            string assetsName = $"Assets/Bundles/UI/Other/HeadInfos.prefab";
            GameObject bundleGameObject =
                    await self.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);

            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject, parentTransform);

            self.Transform = go.transform;
            self.Transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            self.Transform.localPosition = new Vector3(0, offset, 0);

            ReferenceCollector rc = go.GetComponent<ReferenceCollector>();
            self.Slider_HealthBar_Miniboss = rc.Get<GameObject>("Slider_HealthBar_Miniboss");

            self.MainCameraTransform = Camera.main.transform;
        }
    }
}