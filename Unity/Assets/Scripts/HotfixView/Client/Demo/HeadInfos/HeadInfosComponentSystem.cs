﻿using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(HeadInfosComponent))]
    [EntitySystemOf(typeof(HeadInfosComponent))]
    public static partial class HeadInfosComponentSystem
    {
        [EntitySystem]
        private static void Awake(this HeadInfosComponent self, GameObject gameObject)
        {
            self.Transform = gameObject.transform;
            self.Transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            self.Transform.localPosition = new Vector3(0, 2f, 0);

            ReferenceCollector rc = self.Transform.GetComponent<ReferenceCollector>();
            self.HealthBarFillImg = rc.Get<GameObject>("HealthBarFillImg").GetComponent<Image>();

            self.MainCameraTransform = Camera.main.transform;
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

        public static void SetScale(this HeadInfosComponent self, Vector3 vector3)
        {
            self.Transform.localScale = vector3;
        }

        public static void SetPosition(this HeadInfosComponent self, Vector3 vector3)
        {
            self.Transform.localPosition = vector3;
        }

        public static void RefreshHealthBar(this HeadInfosComponent self, float value)
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