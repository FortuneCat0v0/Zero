using DG.Tweening;
using TMPro;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class HitResult_View : AEvent<Scene, HitResult>
    {
        protected override async ETTask Run(Scene scene, HitResult args)
        {
            string str = string.Empty;
            if (args.HitResultType == EHitResultType.Damage)
            {
                str = args.Value.ToString();
            }
            else if (args.HitResultType == EHitResultType.RecoverBlood)
            {
                str = args.Value.ToString();
            }
            else if (args.HitResultType == EHitResultType.Doge)
            {
                str = "闪避";
            }
            else if (args.HitResultType == EHitResultType.Crit)
            {
                str = args.Value.ToString() + "!!!";
            }

            scene.GetComponent<HitResultTipComponent>().ShowHitResultTip(args.ToUnit.Position, str);
            await ETTask.CompletedTask;
        }
    }

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
            go.transform.SetParent(self.Root().GetComponent<GlobalComponent>().Unit);
            self.HitResultTips.Add(go);
            go.SetActive(true);

            go.GetComponent<TMP_Text>().text = str;

            Vector3 randomStart = new(start.x + RandomHelper.RandomNumberFloat(0, 1f), start.y + RandomHelper.RandomNumberFloat(0, 1f),
                start.z + RandomHelper.RandomNumberFloat(0, 1f));

            RectTransform rectTransform = go.transform.GetComponent<RectTransform>();
            rectTransform.position = randomStart;
            rectTransform.localScale = Vector3.one;

            rectTransform.forward = self.Root().GetComponent<GlobalComponent>().MainCamera.forward;

            rectTransform.DOMoveY(randomStart.y + 3f, 1.5f).SetEase(Ease.OutQuad).onComplete = () =>
            {
                go.SetActive(false);
                self.HitResultTips.Remove(go);
                GameObjectPoolHelper.ReturnObjectToPool(go);
            };
        }
    }
}