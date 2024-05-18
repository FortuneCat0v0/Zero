using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(SkillIndicatorComponent))]
    [EntitySystemOf(typeof(SkillIndicatorComponent))]
    public static partial class SkillIndicatorComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillIndicatorComponent self)
        {
            self.OnAwake().Coroutine();
        }

        private static async ETTask OnAwake(this SkillIndicatorComponent self)
        {
            foreach (ESkillIndicatorType eSkillIndicatorType in Enum.GetValues(typeof(ESkillIndicatorType)))
            {
                GameObject bundleGameObject = await self.Scene().GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetAsync<GameObject>($"Assets/Bundles/Effect/SkillIndicator_{eSkillIndicatorType.ToString()}.prefab");
                GameObjectPoolHelper.InitPoolFormGamObject(bundleGameObject, 2);
            }
        }

        public static void ShowIndicator(this SkillIndicatorComponent self, long targetUnitId, SkillConfig skillconfig)
        {
            self.SkillConfig = skillconfig;
            if (self.GameObject != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.GameObject);
                self.GameObject = null;
            }

            self.GameObject = GameObjectPoolHelper.GetObjectFromPool($"SkillIndicator_{self.SkillConfig.SkillIndicatorType.ToString()}");
            self.GameObject.transform.SetParent(UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<GameObjectComponent>().GameObject
                    .transform);

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            switch (self.SkillConfig.SkillIndicatorType)
            {
                case ESkillIndicatorType.Position:
                {
                    // rc.Get<GameObject>("CommonCircle").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    // rc.Get<GameObject>("PositionCircle").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[1];
                    break;
                }
                case ESkillIndicatorType.Line:
                {
                    // rc.Get<GameObject>("Arrow").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    break;
                }
                case ESkillIndicatorType.Angle:
                {
                    // rc.Get<GameObject>("AngleCircle").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    // rc.Get<GameObject>("AngleCircleIndicator").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    break;
                }
                case ESkillIndicatorType.TargetOnly:
                {
                    // rc.Get<GameObject>("CommonCircle").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    // rc.Get<GameObject>("TargetCircle").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[1];
                    break;
                }
            }

            self.GameObject.SetActive(true);
        }

        public static void UpdateIndicator(this SkillIndicatorComponent self, Vector2 vector2)
        {
            self.Vector2 = vector2;

            if (self.SkillConfig == null)
            {
                return;
            }

            if (self.GameObject == null)
            {
                return;
            }

            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Vector3 unitPosition = myUnit.Position;

            if (self.SkillConfig.SkillIndicatorType == ESkillIndicatorType.Position ||
                self.SkillConfig.SkillIndicatorType == ESkillIndicatorType.TargetOnly)
            {
            }

            float angle = 90 - Mathf.Atan2(self.Vector2.y, self.Vector2.x) * Mathf.Rad2Deg;
            angle += self.MainCamera.transform.eulerAngles.y;
            Quaternion quaternion = Quaternion.Euler(0, angle, 0);
            self.Angle = angle;

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            switch (self.SkillConfig.SkillIndicatorType)
            {
                case ESkillIndicatorType.Position:
                {
                    rc.Get<GameObject>("Skill_InnerArea").transform.localPosition =
                            quaternion * Vector3.forward * (self.SkillConfig.SkillIndicatorParams[0] * vector2.magnitude);
                    break;
                }
                case ESkillIndicatorType.Line:
                {
                    rc.Get<GameObject>("Skill_Dir").transform.LookAt(quaternion * Vector3.forward + unitPosition);
                    break;
                }
                case ESkillIndicatorType.Angle:
                {
                    rc.Get<GameObject>("Skill_Area_60").transform.LookAt(quaternion * Vector3.forward + unitPosition);
                    break;
                }
                case ESkillIndicatorType.TargetOnly:
                {
                    rc.Get<GameObject>("Skill_Dir").transform.LookAt(quaternion * Vector3.forward + unitPosition);
                    rc.Get<GameObject>("Skill_InnerArea").transform.localPosition =
                            quaternion * Vector3.forward * (self.SkillConfig.SkillIndicatorParams[0] * vector2.magnitude);

                    // 锁定最近的怪物。。

                    break;
                }
            }
        }

        public static void HideIndicator(this SkillIndicatorComponent self)
        {
            self.SkillConfig = null;
            if (self.GameObject != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.GameObject);
                self.GameObject = null;
            }

            self.Angle = 0;
        }

        public static float GetIndicatorAngle(this SkillIndicatorComponent self)
        {
            if (self.Angle != 0)
            {
                return self.Angle;
            }
            else
            {
                Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
                if (unit != null)
                {
                    Quaternion quaternion = unit.Rotation;
                    return quaternion.eulerAngles.y;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static Vector3 GetIndicatorPosition(this SkillIndicatorComponent self)
        {
            if (self.GameObject == null)
            {
                return Vector3.zero;
            }

            return self.GameObject.transform.position;
        }
    }
}