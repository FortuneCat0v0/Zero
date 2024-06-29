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
            FlyTipComponent.Instance = self;
        }

        [EntitySystem]
        private static void Destroy(this FlyTipComponent self)
        {
            foreach (GameObject flyTip in self.FlyTips)
            {
                flyTip.transform.DOKill();
                UnityEngine.Object.Destroy(flyTip);
            }

            self.FlyTips.Clear();
        }

        [EntitySystem]
        private static void Update(this FlyTipComponent self)
        {
            if (self.FlyTipQueue.Count > 0)
            {
                long time = TimeInfo.Instance.ClientNow();
                if (time - self.LastSpawnFlyTipTime >= self.Interval)
                {
                    self.LastSpawnFlyTipTime = time;
                    self.SpawnFlyTip(self.FlyTipQueue.Dequeue());
                }
            }
        }

        public static void ShowFlyTip(this FlyTipComponent self, string str)
        {
            self.FlyTipQueue.Enqueue(str);
        }

        private static void SpawnFlyTip(this FlyTipComponent self, string str)
        {
            Vector3 startPos = new(0, -200, 0);
            GameObject go = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), "Assets/Bundles/UI/Other/FlyTip.prefab");
            go.transform.SetParent(self.Root().GetComponent<UIGlobalComponent>().GetLayer((int)UILayer.High));
            self.FlyTips.Add(go);
            go.SetActive(true);

            RectTransform rectTransform = go.transform.GetComponent<RectTransform>();
            rectTransform.localPosition = startPos;
            rectTransform.localScale = Vector3.one;
            rectTransform.DOMoveY(0, 2f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                go.SetActive(false);
                self.FlyTips.Remove(go);
                GameObjectPoolHelper.ReturnObjectToPool(go);
            };

            Text text = go.GetComponentInChildren<Text>();
            text.text = str;
            text.color = Color.white;
            text.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);

            Image image = go.GetComponentInChildren<Image>();
            image.color = Color.white;
            image.DOColor(new Color(255, 255, 255, 0), 2f).SetEase(Ease.OutQuad);
        }
    }
}