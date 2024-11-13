namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_AllSlimesHandler : MessageHandler<Scene, M2C_AllSlimes>
    {
        protected override async ETTask Run(Scene root, M2C_AllSlimes message)
        {
            SlimeComponent slimeComponent = root.GetComponent<SlimeComponent>();

            foreach (SlimeInfo slimeInfo in message.SlimeInfos)
            {
                Slime slime = slimeComponent.AddChildWithId<Slime>(slimeInfo.Id);
                slime.FromMessage(slimeInfo);
                slimeComponent.Add(slime);
            }

            await ETTask.CompletedTask;
        }
    }
}