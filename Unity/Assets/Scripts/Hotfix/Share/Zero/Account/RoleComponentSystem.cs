using System.Collections.Generic;
using System.Linq;

namespace ET
{
    [FriendOf(typeof(RoleComponent))]
    [EntitySystemOf(typeof(RoleComponent))]
    public static partial class RoleComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RoleComponent self)
        {
        }

        public static bool Add(this RoleComponent self, long id)
        {
            if (self.RoleIds.Contains(id))
            {
                return false;
            }

            self.RoleIds.Add(id);
            return true;
        }

        public static Role Get(this RoleComponent self, long id)
        {
            if (!self.RoleIds.Contains(id))
            {
                return null;
            }

            return self.GetChild<Role>(id);
        }

        public static List<Role> GetAll(this RoleComponent self)
        {
            return self.Children.Values.Select(entity => entity as Role).ToList();
        }

        public static void Remove(this RoleComponent self, long id)
        {
            if (!self.RoleIds.Contains(id))
            {
                return;
            }

            Role role = self.GetChild<Role>(id);
            role.Dispose();
        }
    }
}