namespace ET.Server
{
    [FriendOf(typeof(MailComponent))]
    [FriendOf(typeof(MailInfoEntity))]
    [MessageHandler(SceneType.Mail)]
    public class C2Mail_GetAllMailListHandler : MessageHandler<MailUnit, C2Mail_GetAllMailList, Mail2C_GetAllMailList>
    {
        protected override async ETTask Run(MailUnit mailUnit, C2Mail_GetAllMailList request, Mail2C_GetAllMailList response)
        {
            MailComponent mailComponent = mailUnit.GetComponent<MailComponent>();

            foreach (MailInfoEntity mailInfoEntity in mailComponent.MailInfosList)
            {
                MailInfo mailInfo = MailInfo.Create();
                mailInfo.MailId = mailInfoEntity.Id;
                mailInfo.Title = mailInfoEntity.Title;
                mailInfo.Message = mailInfoEntity.Message;
                response.MailInfoList.Add(mailInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}