namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GMCMDHandler : MessageLocationHandler<Unit, C2M_GM, M2C_GM>
    {
        protected override async ETTask Run(Unit unit, C2M_GM request, M2C_GM response)
        {
            if (string.IsNullOrEmpty(request.GMMessage))
            {
                return;
            }

            string[] cmd = request.GMMessage.Split(' ');
            if (cmd.Length == 0)
            {
                return;
            }

            if (cmd[0] == ".AddItem")
            {
            }
            else if (cmd[0] == ".AddSkill")
            {
                SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
                skillComponent.AddSkill(int.Parse(cmd[1]));
            }
            else if (cmd[0] == ".UpSkill")
            {
                SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
                // skillComponent.UpSkill(int.Parse(cmd[1]), int.Parse(cmd[2]));
            }
            else if (cmd[0] == ".Recharge")
            {
                response.Error = ItemHelper.Recharge(unit, int.Parse(cmd[1]));
            }

            await ETTask.CompletedTask;
        }
    }
}