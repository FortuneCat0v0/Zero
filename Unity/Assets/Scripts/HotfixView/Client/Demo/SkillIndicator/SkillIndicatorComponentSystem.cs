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
        }

        public static void OnPointerDown(this SkillIndicatorComponent self, long targetUnitId, SkillConfig skillconfig)
        {
            self.SkillIndicatorType = skillconfig.SkillIndicatorType;
            if (self.GameObject != null)
            {
                GameObjectPoolHelper.ReturnObjectToPool(self.GameObject);
                self.GameObject = null;
            }

            self.GameObject = GameObjectPoolHelper.GetObjectFromPool($"{self.SkillIndicatorType.ToString()}");
            self.GameObject.transform.SetParent(UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<GameObjectComponent>().GameObject
                    .transform);

            ReferenceCollector rc = self.GameObject.GetComponent<ReferenceCollector>();
            switch (self.SkillIndicatorType)
            {
                case ESkillIndicatorType.CommonAttack:
                    rc.Get<GameObject>("Skill_Area").transform.localScale = Vector3.one;
                    break;
                case ESkillIndicatorType.Position:
                {
                    float innerRadius = 2f;
                    float outerRadius = 4f;
                    rc.Get<GameObject>("Skill_InnerArea").transform.localScale = Vector3.one * innerRadius;
                    rc.Get<GameObject>("Skill_Area").transform.localScale = Vector3.one * outerRadius;
                    break;
                }
                case ESkillIndicatorType.Line:
                {
                    float innerRadius = 2f;
                    float outerRadius = 4f;
                    rc.Get<GameObject>("Skill_Dir").transform.localScale = Vector3.one * innerRadius;
                    rc.Get<GameObject>("Skill_Area").transform.localScale = Vector3.one * outerRadius;
                    break;
                }
                case ESkillIndicatorType.Angle:
                {
                    float innerRadius = 2f;
                    float outerRadius = 4f;
                    rc.Get<GameObject>("Skill_Area_60").transform.localScale = Vector3.one * innerRadius;
                    rc.Get<GameObject>("Skill_Area").transform.localScale = Vector3.one * outerRadius;
                    break;
                }
                case ESkillIndicatorType.TargetOnly:
                {
                    float innerRadius = 2f;
                    float outerRadius = 4f;
                    rc.Get<GameObject>("Skill_Dir").transform.localScale = Vector3.one * innerRadius;
                    rc.Get<GameObject>("Skill_Area").transform.localScale = Vector3.one * outerRadius;
                    break;
                }
            }

            self.GameObject.SetActive(true);
        }

        public static void OnDrag(this SkillIndicatorComponent self, Vector2 vector2)
        {
            self.Vector2 = vector2;

            if (self.GameObject == null)
            {
                return;
            }

            if (self.SkillIndicatorType == ESkillIndicatorType.Position || self.SkillIndicatorType == ESkillIndicatorType.TargetOnly)
            {
                
            }
        }
    }
}