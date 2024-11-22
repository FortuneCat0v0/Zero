namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GetAllSlimeHandler : MessageLocationHandler<Unit, C2M_GetAllSlime, M2C_GetAllSlime>
    {
        protected override async ETTask Run(Unit unit, C2M_GetAllSlime request, M2C_GetAllSlime response)
        {
            using (ListComponent<Slime> slimes = ListComponent<Slime>.Create())
            {
                unit.GetComponent<SlimeComponent>().GetSlimes(slimes);
                foreach (Slime slime in slimes)
                {
                    response.SlimeList.Add(slime.ToMessage());
                }
            }

            await ETTask.CompletedTask;
        }
    }
}