namespace ET.Server
{
    public static class ItemNoticeHelper
    {
        public static void SyncItemInfo(Unit unit, Item item, ItemOpType itemOpType)
        {
            M2C_ItemUpdateOp m2CItemUpdateOp = M2C_ItemUpdateOp.Create();
            m2CItemUpdateOp.ItemInfo = item.ToMessage();
            m2CItemUpdateOp.ItemOpType = (int)itemOpType;
            MapMessageHelper.SendToClient(unit, m2CItemUpdateOp);
        }
    }
}