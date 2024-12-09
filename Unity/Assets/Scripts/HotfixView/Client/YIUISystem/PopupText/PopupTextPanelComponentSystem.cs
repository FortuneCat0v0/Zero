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
            popupTextPanelComponent.PopupText(str, Vector2.zero, args.ToUnit.GetComponent<GameObjectComponent>().GameObject.transform,
                PopupTextType.Text_0, PopupTextLayer.Layer_0, PopupTextExecuteType.Type_0);

            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(PopupTextPanelComponent))]
    public static partial class PopupTextPanelComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this PopupTextPanelComponent self)
        {
            GameObjectPoolHelper.InitPoolFormGamObject(self.u_ComPopupText_0RectTransform.name, self.u_ComPopupText_0RectTransform.gameObject);
            GameObjectPoolHelper.InitPoolFormGamObject(self.u_ComPopupText_1RectTransform.name, self.u_ComPopupText_1RectTransform.gameObject);
            GameObjectPoolHelper.InitPoolFormGamObject(self.u_ComPopupText_2RectTransform.name, self.u_ComPopupText_2RectTransform.gameObject);
            self.u_ComPopupText_0RectTransform.gameObject.SetActive(false);
            self.u_ComPopupText_1RectTransform.gameObject.SetActive(false);
            self.u_ComPopupText_2RectTransform.gameObject.SetActive(false);
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

        public static void PopupText(this PopupTextPanelComponent self,
        string text,
        Vector2 startPosition,
        Transform targetTransform,
        PopupTextType popupTextType,
        PopupTextLayer popupTextLayer,
        PopupTextExecuteType popupTextExecuteType)
        {
            GameObject gameObject = null;
            switch (popupTextType)
            {
                case PopupTextType.Text_0:
                    gameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), self.u_ComPopupText_0RectTransform.name);
                    break;
                case PopupTextType.Text_1:
                    gameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), self.u_ComPopupText_1RectTransform.name);
                    break;
                case PopupTextType.Text_2:
                    gameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(), self.u_ComPopupText_2RectTransform.name);
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

            RectTransform rootRect = gameObject.GetComponent<RectTransform>();
            rootRect.localPosition = Vector3.zero;
            rootRect.localScale = Vector3.one;

            TMP_Text tmpText = gameObject.GetComponentInChildren<TMP_Text>();
            tmpText.text = text;
            RectTransform textRect = tmpText.GetComponent<RectTransform>();
            textRect.localPosition = Vector3.zero;
            textRect.localScale = Vector3.one;

            self.ExecutingGameObjects.Add(gameObject);
            switch (popupTextExecuteType)
            {
                case PopupTextExecuteType.Type_0:
                {
                    if (targetTransform == null)
                    {
                        return;
                    }

                    RectTransformUtility.ScreenPointToLocalPointInRectangle(YIUIMgrComponent.Inst.UICanvas.GetComponent<RectTransform>(),
                        self.MainCamera.WorldToScreenPoint(targetTransform.position), YIUIMgrComponent.Inst.UICamera, out startPosition);
                    rootRect.localPosition = startPosition;

                    // 初始缩放效果，模拟突然跳出
                    textRect.localScale = Vector3.zero;
                    textRect
                            .DOScale(new Vector3(3, 3, 1f), 0.2f)
                            .SetEase(Ease.OutBack)
                            .OnComplete(() =>
                            {
                                // 缩放回正常大小
                                textRect.DOScale(Vector3.one, 0.1f).SetEase(Ease.InOutBounce);
                            });

                    Vector2 pos = new(0, 100f);
                    textRect.localPosition = pos;
                    pos.y += 100f;
                    Vector2 targetPosition = pos;
                    // 移动
                    textRect
                            .DOLocalMove(targetPosition, 0.5f)
                            .SetEase(Ease.OutQuad)
                            .OnUpdate(() =>
                            {
                                if (targetTransform == null)
                                {
                                    return;
                                }

                                // 跟随目标
                                RectTransformUtility.ScreenPointToLocalPointInRectangle(YIUIMgrComponent.Inst.UICanvas.GetComponent<RectTransform>(),
                                    self.MainCamera.WorldToScreenPoint(targetTransform.position), YIUIMgrComponent.Inst.UICamera, out startPosition);
                                rootRect.localPosition = startPosition;
                            })
                            .OnComplete(() =>
                            {
                                self.ExecutingGameObjects.Remove(gameObject);
                                GameObjectPoolHelper.ReturnObjectToPool(gameObject);
                            });
                    break;
                }
                case PopupTextExecuteType.Type_1:
                {
                    if (targetTransform == null)
                    {
                        return;
                    }

                    RectTransformUtility.ScreenPointToLocalPointInRectangle(YIUIMgrComponent.Inst.UICanvas.GetComponent<RectTransform>(),
                        self.MainCamera.WorldToScreenPoint(targetTransform.position), YIUIMgrComponent.Inst.UICamera, out startPosition);
                    rootRect.localPosition = startPosition;

                    // 初始缩放效果，模拟突然跳出
                    textRect.localScale = Vector3.zero;
                    textRect
                            .DOScale(new Vector3(3, 3, 1f), 0.2f)
                            .SetEase(Ease.OutBack)
                            .OnComplete(() =>
                            {
                                // 缩放回正常大小
                                textRect.DOScale(Vector3.one, 0.1f).SetEase(Ease.InOutBounce);
                            });

                    Vector2 pos = new(RandomGenerator.RandomNumberFloat(-100f, 100f), RandomGenerator.RandomNumberFloat(50f, 200f));
                    textRect.localPosition = pos;
                    pos.x += RandomGenerator.RandomNumberFloat(-50f, 50f);
                    pos.y += RandomGenerator.RandomNumberFloat(-50f, 50f);
                    Vector2 targetPosition = pos;
                    // 移动
                    textRect
                            .DOLocalMove(targetPosition, 0.5f)
                            .SetEase(Ease.OutQuad)
                            .OnUpdate(() =>
                            {
                                if (targetTransform == null)
                                {
                                    return;
                                }

                                // 跟随目标
                                RectTransformUtility.ScreenPointToLocalPointInRectangle(YIUIMgrComponent.Inst.UICanvas.GetComponent<RectTransform>(),
                                    self.MainCamera.WorldToScreenPoint(targetTransform.position), YIUIMgrComponent.Inst.UICamera, out startPosition);
                                rootRect.localPosition = startPosition;
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