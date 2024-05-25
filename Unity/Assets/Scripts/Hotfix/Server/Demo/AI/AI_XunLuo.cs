using Unity.Mathematics;

namespace ET.Server
{
    public class AI_XunLuo : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            long sec = TimeInfo.Instance.ClientNow() / 1000 % 15;
            if (sec < 10)
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