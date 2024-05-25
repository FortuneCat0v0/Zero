namespace ET
{
    public enum QuestState
    {
        RequirementsNotMet,
        CanStart,
        InProgress,
        CanFinish,
        Finished
    }

    [ChildOf(typeof(QuestComponent))]
    public class Quest : Entity, IAwake, ISerializeToEntity
    {
        public int ConfigId { get; set; }
        public int State { get; set; }
        public int CurrentQuestStepIndex { get; set; }
    }
}