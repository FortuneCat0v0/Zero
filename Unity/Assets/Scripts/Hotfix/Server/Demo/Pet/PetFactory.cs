namespace ET.Server
{
    public static class PetFactory
    {
        public static Pet CreateSlime(PetComponent parent, int configId)
        {
            // if (!ItemConfigCategory.Instance.DataMap.ContainsKey(configId))
            // {
            //     Log.Error($"当前所创建的物品ID不存在：{configId}");
            // }

            Pet pet = parent.AddChild<Pet>();

            return pet;
        }
    }
}