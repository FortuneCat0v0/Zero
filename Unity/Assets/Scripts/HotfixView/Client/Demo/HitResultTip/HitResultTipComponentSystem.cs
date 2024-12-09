using DG.Tweening;
using TMPro;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(HitResultTipComponent))]
    [EntitySystemOf(typeof(HitResultTipComponent))]
    public static partial class HitResultTipComponentSystem
    {
        [EntitySystem]
        private static void Awake(this HitResultTipComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this HitResultTipComponent self)
        {
            foreach (GameObject flyTip in self.HitResultTips)
            {
                flyTip.transform.DOKill();
                UnityEngine.Object.Destroy(flyTip);
            }

            self.HitResultTips.Clear();
        }

        public static void ShowHitResultTip(this HitResultTipComponent self, Vector3 start, string str)
        {
            GameObject go = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), "Assets/Bundles/UI/Other/HitResultTip.prefab");
            go.transform.SetParent(self.Root().GetComponent<GlobalComponent>().UnitRoot);
            self.HitResultTips.Add(go);
            go.SetActive(true);

            go.GetComponent<TMP_Text>().text = str;

            Vector3 randomStart = new(start.x + RandomGenerator.RandomNumberFloat(-1, 1f), start.y + RandomGenerator.RandomNumberFloat(0.5f, 1f),
                start.z + RandomGenerator.RandomNumberFloat(-1, 1f));

            RectTransform rectTransform = go.transform.GetComponent<RectTransform>();
            rectTransform.position = randomStart;
            rectTransform.localScale = Vector3.one;

            rectTransform.forward = self.Root().GetComponent<GlobalComponent>().MainCamera.forward;

            // 添加震动效果
            float shakeMagnitude = 1f; // 震动幅度
            float shakeDuration = 1f; // 震动持续时间

            rectTransform.DOPunchPosition(new Vector3(RandomGenerator.RandomNumberFloat(-shakeMagnitude, shakeMagnitude),
                RandomGenerator.RandomNumberFloat(-shakeMagnitude, shakeMagnitude),
                0), shakeDuration);

            // 飘字移动和旋转
            float moveDuration = 1.5f;
            float rotationDuration = 1f;

            rectTransform.DORotate(new Vector3(0, 0, RandomGenerator.RandomNumberFloat(-15f, 15f)), rotationDuration, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutQuad).SetRelative();

            rectTransform.DOMoveY(randomStart.y + 3f, moveDuration).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                go.SetActive(false);
                self.HitResultTips.Remove(go);
                GameObjectPoolHelper.ReturnObjectToPool(go);
            });
        }
    }
}