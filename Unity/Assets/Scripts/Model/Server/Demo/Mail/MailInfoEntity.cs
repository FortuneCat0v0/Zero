namespace ET.Server
{
    [ChildOf(typeof(MailComponent))]
    public class MailInfoEntity : Entity, IAwake, IDestroy, ISerializeToEntity
    {
        public string Title;
        public string Message;
    }
}