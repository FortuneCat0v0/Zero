namespace ET.Server
{
    [MessageHandler(SceneType.Mail)]
    public class G2Mail_ExitMailServerHandler : MessageLocationHandler<MailUnit, G2Mail_ExitMailServer, Mail2G_ExitMailServer>
    {
        protected override async ETTask Run(MailUnit mailUnit, G2Mail_ExitMailServer request, Mail2G_ExitMailServer response)
        {
            mailUnit.GetComponent<MailComponent>().BeginInit();
            await mailUnit.Root().GetComponent<DBManagerComponent>().GetZoneDB(mailUnit.Zone()).Save(mailUnit.GetComponent<MailComponent>());

            MailUnitExit(mailUnit).Coroutine();

            await ETTask.CompletedTask;
        }

        private async ETTask MailUnitExit(MailUnit mailUnit)
        {
            await mailUnit.Fiber().WaitFrameFinish();
            await mailUnit.RemoveLocation(LocationType.Mail);
            mailUnit.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Remove(mailUnit.Id);
            mailUnit?.Dispose();

            await ETTask.CompletedTask;
        }
    }
}