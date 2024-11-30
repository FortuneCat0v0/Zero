using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class RankComponent : Entity, IAwake, IDestroy
    {
        public List<EntityRef<RankEntity>> RankInfos = new();
    }
}