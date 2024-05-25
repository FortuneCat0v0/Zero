namespace ET
{
    [FriendOf(typeof(Role))]
    public static class RoleSystem
    {
        public static void FromMessage(this Role self, RoleInfo roleInfo)
        {
            self.Name = roleInfo.Name;
            self.State = roleInfo.State;
            self.AccountId = roleInfo.AccountId;
            self.CreateTime = roleInfo.CreateTime;
            self.ServerId = roleInfo.ServerId;
            self.LastLoginTime = roleInfo.LastLoginTime;
        }

        public static RoleInfo ToMessage(this Role self)
        {
            RoleInfo roleInfo = RoleInfo.Create();
            roleInfo.Id = self.Id;
            roleInfo.Name = self.Name;
            roleInfo.State = self.State;
            roleInfo.AccountId = self.AccountId;
            roleInfo.CreateTime = self.CreateTime;
            roleInfo.ServerId = self.ServerId;
            roleInfo.LastLoginTime = self.LastLoginTime;

            return roleInfo;
        }
    }
}