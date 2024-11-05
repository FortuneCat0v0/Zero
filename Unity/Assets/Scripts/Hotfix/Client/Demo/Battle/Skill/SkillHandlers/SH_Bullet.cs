namespace ET.Client
{
    public class SH_Bullet : SkillCHandler
    {
        public override void OnInit(SkillC skillS)
        {
        }

        public override void OnUpdate(SkillC skillS)
        {
            skillS.SkillState = ESkillState.Finished;
        }

        public override void OnFinish(SkillC skillS)
        {
        }
    }
}