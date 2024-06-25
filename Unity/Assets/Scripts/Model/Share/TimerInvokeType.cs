namespace ET
{
    [UniqueId(100, 10000)]
    public static class TimerInvokeType
    {
        // 框架层100-200，逻辑层的timer type从200起
        public const int WaitTimer = 100;
        public const int SessionIdleChecker = 101;
        public const int MessageLocationSenderChecker = 102;
        public const int MessageSenderChecker = 103;

        // 框架层100-200，逻辑层的timer type 200-300
        public const int MoveTimer = 201;
        public const int AITimer = 202;
        public const int SessionAcceptTimeout = 203;

        public const int RoomUpdate = 301;
        public const int AccountSessionCheckOutTime = 302;
        public const int PlayerOfflineOutTime = 303;
        public const int NoticeUnitNumericTime = 304;
        public const int SaveChangeDBData = 305;
        public const int RefreshMonsterInMap = 306;
        public const int SkillTimer_Client = 307;
        public const int SkillTimer_Server = 308;
        public const int EffectTimer = 309;
    }
}