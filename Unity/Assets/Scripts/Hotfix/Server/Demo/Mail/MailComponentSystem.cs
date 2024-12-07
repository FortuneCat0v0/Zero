namespace ET.Server
{
    [FriendOf(typeof(MailInfoEntity))]
    [FriendOf(typeof(MailComponent))]
    [EntitySystemOf(typeof(MailComponent))]
    public static partial class MailComponentSystem
    {
        [EntitySystem]
        private static void Awake(this MailComponent self)
        {
            // 测试
            MailInfoEntity mailInfoEntity1 = self.AddChild<MailInfoEntity>();
            mailInfoEntity1.Title = "第一封邮件";
            mailInfoEntity1.Message = "第一封邮件的具体内容";
            self.MailInfosList.Add(mailInfoEntity1);

            MailInfoEntity mailInfoEntity2 = self.AddChild<MailInfoEntity>();
            mailInfoEntity2.Title = "第二封邮件";
            mailInfoEntity2.Message = "第二封邮件的具体内容";
            self.MailInfosList.Add(mailInfoEntity2);
        }

        [EntitySystem]
        private static void Destroy(this MailComponent self)
        {
            self.MailInfosList.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this MailComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                if (entity is MailInfoEntity mailInfoEntity)
                {
                    self.MailInfosList.Add(mailInfoEntity);
                }
            }
        }
    }
}