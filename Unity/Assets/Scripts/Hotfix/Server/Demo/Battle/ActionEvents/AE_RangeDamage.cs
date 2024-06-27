using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.Mathematics;

namespace ET.Server
{
    /// <summary>
    /// 执行范围伤害技能事件
    /// </summary>
    public class AE_RangeDamage : AActionEvent
    {
        public override async ETTask Execute(Skill skill, List<int> param, ETCancellationToken cancellationToken)
        {
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
    }
}