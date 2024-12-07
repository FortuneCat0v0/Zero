namespace ET.Server.Handler
{
    [MessageHandler(SceneType.Mail)]
    public class G2Mail_LoginMailServerHandler : MessageHandler<Scene, G2Mail_LoginMailServer, Mail2G_LoginMailServer>
    {
        protected override async ETTask Run(Scene scene, G2Mail_LoginMailServer request, Mail2G_LoginMailServer response)
        {
            MailUnitsComponent mailUnitsComponent = scene.GetComponent<MailUnitsComponent>();
            mailUnitsComponent.Children.TryGetValue(request.UnitId, out Entity mailUnitEntity);

            MailUnit mailUnit = mailUnitEntity as MailUnit;

            if (mailUnit != null)
            {
                return;
            }

            mailUnit = mailUnitsComponent.AddChildWithId<MailUnit>(request.UnitId);
            mailUnit.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);

            MailComponent mailComponent = await scene.GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone()).Query<MailComponent>(request.UnitId);

            if (mailComponent == null)
            {
                mailUnit.AddComponent<MailComponent>();
            }
            else
            {
                mailUnit.AddComponent(mailComponent);
            }

            await mailUnit.AddLocation(LocationType.Mail);

            await ETTask.CompletedTask;
        }
    }
}