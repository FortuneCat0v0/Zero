using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class MonsterManagerComponent : Entity, IAwake, IDestroy
    {
        public long Timer;
    }
}