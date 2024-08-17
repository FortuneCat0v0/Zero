using Unity.Mathematics;
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
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
        }

        public static void ShowIndicator(this SkillIndicatorComponent self, long targetUnitId, SkillConfig skillconfig)
        {
            self.SkillConfig = skillconfig;
            if (self.GameObject != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.GameObject);
                self.GameObject = null;
                self.IndicatorGameObject = null;
            }

            self.GameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(),
                $"Assets/Bundles/Effect/SkillIndicator/SkillIndicator_{self.SkillConfig.SkillIndicatorType.ToString()}.prefab");
            self.GameObject.transform.SetParent(UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<GameObjectComponent>().GameObject
                    .transform);
            self.GameObject.transform.localPosition = new Vector3(0, 0.1f, 0);
            self.Vector2 = Vector2.zero;

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            switch (self.SkillConfig.SkillIndicatorType)
            {
                case ESkillIndicatorType.TargetOnly:
                {
                    // rc.Get<GameObject>("Range").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    break;
                }
                case ESkillIndicatorType.Circle:
                {
                    // rc.Get<GameObject>("Circle").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    // rc.Get<GameObject>("Range").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    break;
                }
                case ESkillIndicatorType.Umbrella:
                {
                    // rc.Get<GameObject>("Umbrella").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    // rc.Get<GameObject>("CircleIndicator").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    break;
                }
                case ESkillIndicatorType.Range:
                {
                    // rc.Get<GameObject>("Range").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    break;
                }
                case ESkillIndicatorType.SingleLine:
                {
                    // rc.Get<GameObject>("Line").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[0];
                    // rc.Get<GameObject>("Range").transform.localScale = Vector3.one * self.SkillConfig.SkillIndicatorParams[1];
                    self.IndicatorGameObject = rc.Get<GameObject>("Line");
                    break;
                }
            }

            self.GameObject.SetActive(true);
        }

        public static void UpdateIndicator(this SkillIndicatorComponent self, Vector2 vector2)
        {
            self.Vector2 += vector2;

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

            if (self.SkillConfig.SkillIndicatorType == ESkillIndicatorType.Circle ||
                self.SkillConfig.SkillIndicatorType == ESkillIndicatorType.TargetOnly)
            {
            }

            float angle = 90 - Mathf.Atan2(self.Vector2.y, self.Vector2.x) * Mathf.Rad2Deg;
            angle += self.MainCamera.transform.eulerAngles.y;
            Quaternion qua = Quaternion.Euler(0, angle, 0);

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            switch (self.SkillConfig.SkillIndicatorType)
            {
                case ESkillIndicatorType.TargetOnly:
                {
                    // 锁定最近的怪物。。
                    break;
                }
                case ESkillIndicatorType.Circle:
                {
                    rc.Get<GameObject>("Circle").transform.localPosition =
                            qua * Vector3.forward * (self.SkillConfig.SkillIndicatorParams[0] * vector2.magnitude);
                    break;
                }
                case ESkillIndicatorType.Umbrella:
                {
                    rc.Get<GameObject>("Umbrella").transform.LookAt(qua * Vector3.forward + unitPosition);
                    break;
                }
                case ESkillIndicatorType.Range:
                {
                    break;
                }
                case ESkillIndicatorType.SingleLine:
                {
                    rc.Get<GameObject>("Line").transform.rotation = qua;
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
        }

        public static float GetAngle(this SkillIndicatorComponent self)
        {
            if (self.IndicatorGameObject != null)
            {
                return self.IndicatorGameObject.transform.eulerAngles.y;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit != null)
            {
                Quaternion rotation = unit.Rotation;
                return rotation.eulerAngles.y;
            }

            return default;
        }

        public static float3 GetPosition(this SkillIndicatorComponent self)
        {
            if (self.IndicatorGameObject != null)
            {
                return self.IndicatorGameObject.transform.position;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit != null)
            {
                return unit.Position;
            }

            return default;
        }
    }
}