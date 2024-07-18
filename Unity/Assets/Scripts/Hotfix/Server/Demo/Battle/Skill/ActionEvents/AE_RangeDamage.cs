using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 以自身为中心的范围伤害
    /// 参数：伤害
    /// </summary>
    public class AE_RangeDamage : AActionEvent
    {
        public override async ETTask Execute(Entity entity, List<int> param, ETCancellationToken cancellationToken)
        {
            Skill skill = entity as Skill;
            Scene root = skill.Root();
            Unit owner = skill.OwnerUnit;

            List<Unit> units = new();
            units.AddRange(root.GetComponent<UnitComponent>().GetAll());
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit == null || (unit.Type() != EUnitType.Player && unit.Type() != EUnitType.Monster) || owner.Id == unit.Id)
                {
                    continue;
                }

                float dis = math.distance(owner.Position, unit.Position);

                if (dis <= param[0].ToFloat())
                {
                    BattleHelper.HitSettle(owner, unit, EHitFromType.Skill_Normal, param[1]);
                }
            }

            await ETTask.CompletedTask;
        }

        public override void HandleCollisionStart(Unit a, Unit b)
        {
        }

        public override void HandleCollisionSustain(Unit a, Unit b)
        {
        }

        public override void HandleCollisionEnd(Unit a, Unit b)
        {
        }
    }
}