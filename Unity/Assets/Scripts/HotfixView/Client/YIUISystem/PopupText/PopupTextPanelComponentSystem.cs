using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;

namespace ET.Client
{
    [Event(SceneType.Demo)]
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

            PopupTextPanelComponent popupTextPanelComponent = YIUIMgrComponent.Inst.GetPanel<PopupTextPanelComponent>();
            popupTextPanelComponent.PopupText(str, args.ToUnit.Position, PopupTextType.Text_0, PopupTextLayer.Layer_0, PopupTextExecuteType.Type_0);

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(PopupTextPanelComponent))]
    public static partial class PopupTextPanelComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this PopupTextPanelComponent self)
        {
            GameObjectPoolHelper.InitPoolFormGamObject(self.u_ComText_0RectTransform.name, self.u_ComText_0RectTransform.gameObject);
            GameObjectPoolHelper.InitPoolFormGamObject(self.u_ComText_1RectTransform.name, self.u_ComText_1RectTransform.gameObject);
            GameObjectPoolHelper.InitPoolFormGamObject(self.u_ComText_2RectTransform.name, self.u_ComText_2RectTransform.gameObject);
            self.u_ComText_0RectTransform.gameObject.SetActive(false);
            self.u_ComText_1RectTransform.gameObject.SetActive(false);
            self.u_ComText_2RectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this PopupTextPanelComponent self)
        {
            foreach (GameObject go in self.ExecutingGameObjects)
            {
                go.transform.DOKill();
                UnityEngine.Object.Destroy(go);
            }

            self.ExecutingGameObjects.Clear();
        }

        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this PopupTextPanelComponent self)
        {
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();

            await ETTask.CompletedTask;
            return true;
        }

        public static void PopupText(this PopupTextPanelComponent self, string text, Vector3 worldPosition, PopupTextType popupTextType,
        PopupTextLayer popupTextLayer,
        PopupTextExecuteType popupTextExecuteType)
        {
            GameObject gameObject = null;
            switch (popupTextType)
            {
                case PopupTextType.Text_0:
                    gameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), self.u_ComText_0RectTransform.name);
                    break;
                case PopupTextType.Text_1:
                    gameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), self.u_ComText_1RectTransform.name);
                    break;
                case PopupTextType.Text_2:
                    gameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), self.u_ComText_2RectTransform.name);
                    break;
            }

            switch (popupTextLayer)
            {
                case PopupTextLayer.Layer_0:
                    gameObject.transform.SetParent(self.u_ComLayer_0RectTransform);
                    break;
                case PopupTextLayer.Layer_1:
                    gameObject.transform.SetParent(self.u_ComLayer_1RectTransform);
                    break;
                case PopupTextLayer.Layer_2:
                    gameObject.transform.SetParent(self.u_ComLayer_2RectTransform);
                    break;
            }

            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

            TMP_Text tmpText = gameObject.GetComponent<TMP_Text>();
            tmpText.text = text;

            Vector2 startPoint = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(YIUIMgrComponent.Inst.UICanvas.GetComponent<RectTransform>(),
                self.MainCamera.WorldToScreenPoint(worldPosition), YIUIMgrComponent.Inst.UICamera, out startPoint);

            self.ExecutingGameObjects.Add(gameObject);
            switch (popupTextExecuteType)
            {
                case PopupTextExecuteType.Type_0:
                {
                    startPoint.x += RandomGenerator.RandomNumberFloat(-150f, 150f);
                    startPoint.y += RandomGenerator.RandomNumberFloat(50f, 200f);
                    rectTransform.localPosition = startPoint;

                    // 初始缩放效果，模拟突然跳出
                    rectTransform.localScale = Vector3.zero;
                    rectTransform
                            .DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f)
                            .SetEase(Ease.OutBack)
                            .OnComplete(() =>
                            {
                                // 缩放回正常大小
                                rectTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InOutBounce);
                            });

                    // 移动并淡出
                    rectTransform
                            .DOLocalMoveY(rectTransform.localPosition.y + 50, 1.0f)
                            .SetEase(Ease.OutQuad)
                            .OnComplete(() =>
                            {
                                self.ExecutingGameObjects.Remove(gameObject);
                                GameObjectPoolHelper.ReturnObjectToPool(gameObject);
                            });
                    break;
                }
                case PopupTextExecuteType.Type_1:
                {
                    startPoint.x += RandomGenerator.RandomNumberFloat(-150f, 150f);
                    startPoint.y += RandomGenerator.RandomNumberFloat(50f, 100f);
                    rectTransform.localPosition = startPoint;

                    // 初始缩放效果，模拟突然跳出
                    rectTransform.localScale = Vector3.zero;
                    rectTransform
                            .DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f)
                            .SetRelative(true)
                            .SetEase(Ease.OutBack)
                            .OnComplete(() =>
                            {
                                // 缩放回正常大小
                                rectTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InOutBounce);
                            });

                    // 移动并淡出
                    rectTransform
                            .DOLocalMoveY(rectTransform.localPosition.y + 200, 1.0f)
                            .SetEase(Ease.OutQuad)
                            .OnUpdate(() =>
                            {
                                Color currentColor = tmpText.color;
                                currentColor.a = Mathf.Lerp(1, 0, rectTransform.localPosition.y / 200);
                                tmpText.color = currentColor;
                            })
                            .OnComplete(() =>
                            {
                                self.ExecutingGameObjects.Remove(gameObject);
                                GameObjectPoolHelper.ReturnObjectToPool(gameObject);
                            });
                    break;
                }
            }
        }

        #region YIUIEvent开始

        #endregion YIUIEvent结束
    }
}