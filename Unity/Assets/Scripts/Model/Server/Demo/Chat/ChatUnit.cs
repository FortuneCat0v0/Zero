namespace ET.Server
{
    [ChildOf(typeof(ChatUnitComponent))]
    public class ChatUnit : Entity, IAwake, IDestroy
    {
        public string Name { get; set; }
    }
}