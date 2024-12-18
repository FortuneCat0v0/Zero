﻿using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class UnitCacheComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<string, EntityRef<UnitCache>> UnitCacheDict = new();

        // 所有继承ICache的类型
        public List<string> UnitCacheKeys = new();
    }
}