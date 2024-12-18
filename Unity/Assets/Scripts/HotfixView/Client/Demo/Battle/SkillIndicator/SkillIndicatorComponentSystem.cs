﻿using Unity.Mathematics;
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

        [EntitySystem]
        private static void Update(this SkillIndicatorComponent self)
        {
            if (self.GameObject != null && self.Unit != null)
            {
                self.GameObject.transform.localPosition = self.Unit.Position + new float3(0, 0.1f, 0);
            }
        }

        public static void ShowIndicator(this SkillIndicatorComponent self, SkillConfig skillconfig)
        {
            self.Unit ??= UnitHelper.GetMyUnitFromClientScene(self.Root()); // 以后若是有切换控制对象，通过订阅事件设置对象

            self.Vector2 = Vector2.zero;
            self.SkillConfig = skillconfig;
            if (self.GameObject != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.GameObject);
                self.GameObject = null;
            }

            self.GameObject = GameObjectPoolHelper.GetObjectFromPoolSync(self.Root(),
                $"Assets/Bundles/Effect/SkillIndicator/SkillIndicator_{self.SkillConfig.SkillIndicatorType.ToString()}.prefab");
            self.GameObject.transform.SetParent(self.Root().GetComponent<GlobalComponent>().EffectRoot);
            self.GameObject.transform.localPosition = self.Unit.Position;
            self.GameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

            self.Angle = MathHelper.QuaternionToEulerAngle_Y_Deg(self.Unit.Rotation);
            self.Distance = 0;

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            switch (self.SkillConfig.SkillIndicatorType)
            {
                case SkillIndicatorType.TargetOnly:
                {
                    rc.Get<GameObject>("Range").transform.localScale = new Vector3(self.SkillConfig.CastRange, 1, self.SkillConfig.CastRange);
                    break;
                }
                case SkillIndicatorType.Circle:
                {
                    if (self.SkillConfig.ColliderParams is CircleColliderParams colliderParams)
                    {
                        rc.Get<GameObject>("Circle").transform.localScale = new Vector3(colliderParams.Radius, 1, colliderParams.Radius);
                    }

                    rc.Get<GameObject>("Range").transform.localScale = new Vector3(self.SkillConfig.CastRange, 1, self.SkillConfig.CastRange);
                    break;
                }
                case SkillIndicatorType.Sector:
                {
                    if (self.SkillConfig.ColliderParams is SectorColliderParams colliderParams)
                    {
                        rc.Get<GameObject>("Sector").transform.localScale = new Vector3(colliderParams.Radius, 1, colliderParams.Radius);
                        rc.Get<GameObject>("CircleIndicator").GetComponent<MeshRenderer>().material.SetFloat("_Angle", colliderParams.Angle);
                    }

                    break;
                }
                case SkillIndicatorType.Range:
                {
                    rc.Get<GameObject>("Range").transform.localScale = new Vector3(self.SkillConfig.CastRange, 1, self.SkillConfig.CastRange);

                    break;
                }
                case SkillIndicatorType.SingleLine:
                {
                    rc.Get<GameObject>("Line").transform.localScale = new Vector3(1, 1, self.SkillConfig.CastRange);
                    rc.Get<GameObject>("Line").transform.rotation = Quaternion.Euler(0, self.Angle, 0);
                    rc.Get<GameObject>("Range").transform.localScale = new Vector3(self.SkillConfig.CastRange, 1, self.SkillConfig.CastRange);
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

            float angle = 90 - Mathf.Atan2(self.Vector2.y, self.Vector2.x) * Mathf.Rad2Deg;
            angle += self.MainCamera.transform.eulerAngles.y;

            float distance = self.Vector2.magnitude * self.DistanceFactor;
            if (distance > self.SkillConfig.CastRange)
            {
                distance = self.SkillConfig.CastRange;
            }

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            switch (self.SkillConfig.SkillIndicatorType)
            {
                case SkillIndicatorType.TargetOnly:
                {
                    // 锁定最近的怪物。。
                    // 修改TargetComponent

                    // 这里的Angle是要计算目标与自己
                    self.Angle = 0;
                    self.Distance = 0;
                    break;
                }
                case SkillIndicatorType.Circle:
                {
                    rc.Get<GameObject>("Circle").transform.localPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

                    self.Angle = angle;
                    self.Distance = distance;
                    break;
                }
                case SkillIndicatorType.Sector:
                {
                    rc.Get<GameObject>("Sector").transform.rotation = Quaternion.Euler(0, angle, 0);

                    self.Angle = angle;
                    self.Distance = 0;
                    break;
                }
                case SkillIndicatorType.Range:
                {
                    self.Angle = MathHelper.QuaternionToEulerAngle_Y_Deg(self.Unit.Rotation);
                    self.Distance = 0;
                    break;
                }
                case SkillIndicatorType.SingleLine:
                {
                    rc.Get<GameObject>("Line").transform.rotation = Quaternion.Euler(0, angle, 0);

                    self.Angle = angle;
                    self.Distance = 0;
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
            return self.Angle;
        }

        public static float GetDistance(this SkillIndicatorComponent self)
        {
            return self.Distance;
        }
    }
}