using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(MailUnit))]
    public class MailComponent : Entity, IAwake, IDestroy, IDeserialize
    {
        public List<EntityRef<MailInfoEntity>> MailInfosList = new();
    }
}