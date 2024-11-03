using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class NumericNoticeComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, M2C_NoticeNumericMsg> OutPutMessageDict = new();
        public Queue<IMessage> QueuedMessage = new();
        public long SyncTime = 0;
        public long SyncTimerId = 0;
        public long LastSendTime = 0;
    }
}