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

        public static void Remove(this RoleComponent self, long id)
        {
            for (int i = self.Roles.Count - 1; i >= 0; i--)
            {
                Role role = self.Roles[i];
                if (role.Id != id)
                {
                    continue;
                }

                self.Roles.RemoveAt(i);
                role.Dispose();
            }
        }
    }
}