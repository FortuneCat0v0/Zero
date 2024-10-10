using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class RoleComponent : Entity, IAwake
    {
        public List<EntityRef<Role>> Roles { get; set; } = new();
        public long CurrentRoleId { get; set; }
    }
}