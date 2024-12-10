namespace ET.Server
{
    public static class PetNoticeHelper
    {
        public static void SyncPetInfo(Unit unit, Pet pet, PetOpType petOpType)
        {
            M2C_PetUpdateOp m2CPetUpdateOp = M2C_PetUpdateOp.Create();
            m2CPetUpdateOp.PetInfo = pet.ToMessage();
            m2CPetUpdateOp.PetOpType = (int)petOpType;
            MapMessageHelper.SendToClient(unit, m2CPetUpdateOp);
        }
    }
}