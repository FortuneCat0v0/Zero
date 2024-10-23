using Unity.Mathematics;

namespace ET.Server
{
    public class AI_ZhuiJi : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            Unit myUnit = aiComponent.GetParent<Unit>();
            Unit enemy = myUnit.GetEnemy(8, true);
            if (enemy != null)
            {
                return 0;
            }

            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit myUnit = aiComponent.GetParent<Unit>();
            if (myUnit == null)
            {
                return;
            }

            Unit enemy = myUnit.GetEnemy(8, true);

            for (int i = 0; i < 100000; ++i)
            {
                if (enemy == null)
                {
                    return;
                }

                float distance = math.distance(enemy.Position, myUnit.Position);
                if (distance > 3f)
                {
                    myUnit.FindPathMoveToAsync(MathHelper.GetPointBetween(myUnit.Position, enemy.Position, 2)).Coroutine();
                }

                await aiComponent.Root().GetComponent<TimerComponent>().WaitAsync(1000, cancellationToken);
                if (cancellationToken.IsCancel())
                {
                    return;
                }
            }
        }
    }
}