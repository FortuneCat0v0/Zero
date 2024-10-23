﻿using UnityEngine;
using UnityEngine.UI;
using YIUIFramework;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.NowHp)]
    public class NumericWatcher_Hp_ShowUI : INumericWatcher
    {
        public void Run(Unit unit, NumericChange args)
        {
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            unit.GetComponent<UIHeadInfoComponent>()
                    ?.RefreshHealthBar(numericComponent.GetAsInt(NumericType.NowHp) * 1f / numericComponent.GetAsInt(NumericType.MaxHp));
        }
    }

    [FriendOf(typeof(UIHeadInfoComponent))]
    [EntitySystemOf(typeof(UIHeadInfoComponent))]
    public static partial class UIHeadInfoComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIHeadInfoComponent self, Transform transform)
        {
            self.TargetTransform = transform;
            GameObject go = GameObjectPoolHelper.GetObjectFromPoolSync(self.Scene(), AssetPathHelper.GetUIPath("Other/UIHeadInfo"));
            self.Transform = go.transform;
            self.Transform.SetParent(YIUIMgrComponent.Inst.GetLayerRect(EPanelLayer.Scene));
            self.Transform.localScale = Vector3.one;
            self.Transform.localPosition = Vector3.zero;

            ReferenceCollector rc = self.Transform.GetComponent<ReferenceCollector>();
            self.HealthBarFillImg = rc.Get<GameObject>("HealthBarFillImg").GetComponent<Image>();

            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
        }

        [EntitySystem]
        private static void Destroy(this UIHeadInfoComponent self)
        {
            GameObjectPoolHelper.ReturnObjectToPool(self.Transform.gameObject);
        }

        [EntitySystem]
        private static void LateUpdate(this UIHeadInfoComponent self)
        {
            if (self.Transform == null)
            {
                return;
            }

            if (self.MainCamera == null)
            {
                return;
            }

            Vector2 localPoint = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(YIUIMgrComponent.Inst.UICanvas.GetComponent<RectTransform>(),
                self.MainCamera.WorldToScreenPoint(self.TargetTransform.position), YIUIMgrComponent.Inst.UICamera, out localPoint);

            localPoint.y += 100f;
            self.Transform.localPosition = localPoint;
        }

        public static void SetScale(this UIHeadInfoComponent self, Vector3 vector3)
        {
            self.Transform.localScale = vector3;
        }

        public static void SetPosition(this UIHeadInfoComponent self, Vector3 vector3)
        {
            self.Transform.localPosition = vector3;
        }

        public static void RefreshHealthBar(this UIHeadInfoComponent self, float value)
        {
            if (value > 1)
            {
                value = 1;
            }

            if (value < 0)
            {
                value = 0;
            }

            self.HealthBarFillImg.fillAmount = value;
        }
    }
}