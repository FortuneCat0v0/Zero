using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    public class AI_XunLuo : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            Unit myUnit = aiComponent.GetParent<Unit>();
            Unit enemy = myUnit.GetEnemy(8, true);
            if (enemy != null)
            {
                return 1;
            }

            return 0;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            Unit myUnit = aiComponent.GetParent<Unit>();
            if (myUnit == null)
            {
                return;
            }

            Log.Debug("开始巡逻");

            while (true)
            {
                XunLuoPathComponent xunLuoPathComponent = myUnit.GetComponent<XunLuoPathComponent>();
                float3 nextTarget = xunLuoPathComponent.GetCurrent();
                await myUnit.FindPathMoveToAsync(nextTarget);
                if (cancellationToken.IsCancel())
                {
                    return;
                }

                xunLuoPathComponent.MoveNext();
            }
        }
    }
}