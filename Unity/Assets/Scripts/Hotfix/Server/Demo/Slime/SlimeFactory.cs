namespace ET.Server
{
    public static class SlimeFactory
    {
        public static Slime CreateSlime(SlimeComponent parent, int configId)
        {
            // if (!ItemConfigCategory.Instance.DataMap.ContainsKey(configId))
            // {
            //     Log.Error($"当前所创建的物品ID不存在：{configId}");
            // }

            Slime slime = parent.AddChild<Slime>();

            return slime;
        }
    }
}