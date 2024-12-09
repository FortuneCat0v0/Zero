namespace ET.Client
{
    public class Skill_Bullet : ClientSkillHandler
    {
        public override void OnInit(ClientSkill clientSkillS)
        {
        }

        public override void OnUpdate(ClientSkill clientSkillS)
        {
            clientSkillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(ClientSkill clientSkillS)
        {
        }
    }
}