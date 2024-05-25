using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class AccountSessionComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, long> AccountSessionDictionary = new();
    }
}