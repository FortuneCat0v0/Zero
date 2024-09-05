namespace ET
{
    public static class DefineCore
    {
        [StaticField]
        public static float FixedDeltaTime = 1f / LogicFrame;

        [StaticField]
        public static int LogicFrame = 30;
    }
}