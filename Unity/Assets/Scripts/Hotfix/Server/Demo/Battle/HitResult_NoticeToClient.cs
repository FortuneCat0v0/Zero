namespace ET.Server
{
    [Event(SceneType.Map)]
    public class HitResult_NoticeToClient : AEvent<Scene, HitResult>
    {
        protected override async ETTask Run(Scene scene, HitResult args)
        {
            M2C_HitResult m2CHitResult = M2C_HitResult.Create();
            m2CHitResult.FromUnitId = args.FromUnit.Id;
            m2CHitResult.ToUnitId = args.ToUnit.Id;
            m2CHitResult.HitResultType = (int)args.HitResultType;
            m2CHitResult.Value = args.Value;

            MapMessageHelper.Broadcast(args.ToUnit, m2CHitResult);

            await ETTask.CompletedTask;
        }
    }
}