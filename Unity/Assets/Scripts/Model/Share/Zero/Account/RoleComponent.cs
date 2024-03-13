﻿using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class RoleComponent : Entity, IAwake
    {
        public List<long> RoleIds { get; set; } = new();
        public long CurrentRoleId { get; set; }
    }
}