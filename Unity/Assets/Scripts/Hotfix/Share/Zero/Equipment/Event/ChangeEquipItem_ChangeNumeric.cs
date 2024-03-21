namespace ET.Server
{
    [FriendOf(typeof(AttributeEntry))]
    [Event(SceneType.Map)]
    public class ChangeEquipItem_ChangeNumeric: AEvent<Scene, ChangeEquipItem>
    {
        protected override async ETTask Run(Scene scene, ChangeEquipItem args)
        {
            NumericComponent numericComponent = args.Unit.GetComponent<NumericComponent>();
            foreach (long id in args.Item.AttributeEntryIds)
            {
                AttributeEntry attributeEntry = args.Item.GetChild<AttributeEntry>(id);

                int numericTypeKey = attributeEntry.Key * 10 + 2;
                if (args.EquipOp == EquipOp.Load)
                {
                    numericComponent.Set(numericTypeKey, numericComponent.GetAsLong(numericTypeKey) + attributeEntry.Value);
                }
                else if (args.EquipOp == EquipOp.Unload)
                {
                    numericComponent.Set(numericTypeKey, numericComponent.GetAsLong(numericTypeKey) - attributeEntry.Value);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}

