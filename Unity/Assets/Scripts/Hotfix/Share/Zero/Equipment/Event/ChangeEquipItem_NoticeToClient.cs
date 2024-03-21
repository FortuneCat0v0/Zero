namespace ET.Server
{
    [Event(SceneType.Map)]
    public class ChangeEquipItem_NoticeToClient : AEvent<Scene, ChangeEquipItem>
    {
        protected override async ETTask Run(Scene scene, ChangeEquipItem args)
        {
            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = args.Item.ToMessage();
            m2CItemUpdateOp.ItemOpType = (int)args.EquipOp;
            m2CItemUpdateOp.ItemContainerType = (int)ItemContainerType.Equipment;
            m2CItemUpdateOp.EquipPosition = (int)args.EquipPosition;
            MapMessageHelper.SendToClient(args.Unit, m2CItemUpdateOp);

            await ETTask.CompletedTask;
        }
    }
}

