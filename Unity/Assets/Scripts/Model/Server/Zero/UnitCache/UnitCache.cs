using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof(UnitCacheComponent))]
    public class UnitCache : Entity, IAwake, IDestroy
    {
        public string key;

        /// <summary>
        /// UnitID身上的实体
        /// </summary>
        public Dictionary<long, EntityRef<Entity>> CacheCompoenntsDictionary = new();
    }
}