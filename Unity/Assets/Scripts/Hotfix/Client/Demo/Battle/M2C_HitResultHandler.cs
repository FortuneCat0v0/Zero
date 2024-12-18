﻿namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_HitResultHandler : MessageHandler<Scene, M2C_HitResult>
    {
        protected override async ETTask Run(Scene root, M2C_HitResult message)
        {
            Unit toUnit = root.CurrentScene().GetComponent<UnitComponent>().Get(message.ToUnitId);

            if (toUnit != null)
            {
                EventSystem.Instance.Publish(root,
                    new HitResult() { ToUnit = toUnit, HitResultType = (EHitResultType)message.HitResultType, Value = message.Value });
            }

            await ETTask.CompletedTask;
        }
    }
}