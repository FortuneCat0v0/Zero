using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(FlyTipComponent))]
    [EntitySystemOf(typeof(FlyTipComponent))]
    public static partial class FlyTipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this FlyTipComponent self)
        {
            self.OnAwake().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this FlyTipComponent self)
        {
            foreach (GameObject flyTip in self.FlyTips)
            {
                flyTip.transform.DOKill();
                UnityEngine.Object.Destroy(flyTip);
            }

            foreach (GameObject flyTipDi in self.FlyTipDis)
            {
                flyTipDi.transform.DOKill();
                UnityEngine.Object.Destroy(flyTipDi);
            }

            self.FlyTips.Clear();
            self.FlyTipDis.Clear();
        }

        private static async ETTask OnAwake(this FlyTipComponent self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            GameObject flyTip = await resourcesLoaderComponent.LoadAssetAsync<GameObject>($"Assets/Bundles/UI/Other/FlyTip.prefab");
            GameObjectPoolHelper.InitPoolFormGamObject(flyTip, 3);

            GameObject flyTipDi = await resourcesLoaderComponent.LoadAssetAsync<GameObject>($"Assets/Bundles/UI/Other/FlyTipDi.prefab");
            GameObjectPoolHelper.InitPoolFormGamObject(flyTipDi, 3);
        }

        public static void SpawnFlyTip(this FlyTipComponent self, string str)
        {
            Vector3 startPos = new(0, -100, 0);
            GameObject FlyTipGO = GameObjectPoolHelper.GetObjectFromPool("FlyTip");
            FlyTipGO.transform.SetParent(self.Root().GetComponent<UIGlobalComponent>().GetLayer((int)UILayer.High));
            self.FlyTips.Add(FlyTipGO);
            FlyTipGO.SetActive(true);

            RectTransform rectTransform = FlyTipGO.transform.GetComponent<RectTransform>();
            rectTransform.localPosition = startPos;
            rectTransform.localScale = Vector3.one;
            rectTransform.DOLocalMoveY(0, 2f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                FlyTipGO.SetActive(false);
                self.FlyTips.Remove(FlyTipGO);
                GameObjectPoolHelper.ReturnObjectToPool(FlyTipGO);
            };

            Text text = FlyTipGO.GetComponentInChildren<Text>();
            text.text = str;
            text.color = Color.white;
            text.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);
        }

        public static void SpawnFlyTipDi(this FlyTipComponent self, string str)
        {
            Vector3 startPos = new(0, -100, 0);
            GameObject FlyTipDiGO = GameObjectPoolHelper.GetObjectFromPool("FlyTipDi");
            FlyTipDiGO.transform.SetParent(self.Root().GetComponent<UIGlobalComponent>().GetLayer((int)UILayer.High));
            self.FlyTipDis.Add(FlyTipDiGO);
            FlyTipDiGO.SetActive(true);

            RectTransform rectTransform = FlyTipDiGO.transform.GetComponent<RectTransform>();
            rectTransform.localPosition = startPos;
            rectTransform.localScale = Vector3.one;
            rectTransform.GetComponent<RectTransform>().DOMoveY(0, 2f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                FlyTipDiGO.SetActive(false);
                self.FlyTipDis.Remove(FlyTipDiGO);
                GameObjectPoolHelper.ReturnObjectToPool(FlyTipDiGO);
            };

            Text text = FlyTipDiGO.GetComponentInChildren<Text>();
            text.text = str;
            text.color = Color.white;
            text.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);

            Image image = FlyTipDiGO.GetComponentInChildren<Image>();
            image.color = Color.white;
            image.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);
        }
    }
}