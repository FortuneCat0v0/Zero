namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GMCMDHandler : MessageLocationHandler<Unit, C2M_GMCMD>
    {
        protected override async ETTask Run(Unit unit, C2M_GMCMD message)
        {
            if (string.IsNullOrEmpty(message.CMDMessage))
            {
                return;
            }

            string[] cmd = message.CMDMessage.Split(' ');
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
                skillComponent.AddSkill(int.Parse(cmd[1]), int.Parse(cmd[2]));
            }
            else if (cmd[0] == ".UpSkill")
            {
                SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
                // skillComponent.UpSkill(int.Parse(cmd[1]), int.Parse(cmd[2]));
            }
            else if (cmd[0] == ".SpellSkill")
            {
                SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
                skillComponent.SpellSkill(int.Parse(cmd[1]), default, default, 0);
            }

            await ETTask.CompletedTask;
        }
    }
}