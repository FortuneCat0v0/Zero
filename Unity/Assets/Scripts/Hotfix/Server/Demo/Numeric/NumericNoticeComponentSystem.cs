using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(NumericNoticeComponent))]
    [EntitySystemOf(typeof(NumericNoticeComponent))]
    public static partial class NumericNoticeComponentSystem
    {
        [Invoke(TimerInvokeType.NumericSync)]
        public class NumericSync : ATimer<NumericNoticeComponent>
        {
            protected override void Run(NumericNoticeComponent self)
            {
                self.NoticeQueueMsgImmediately();
            }
        }

        [EntitySystem]
        private static void Awake(this NumericNoticeComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this NumericNoticeComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.SyncTimerId);
            self.LastSendTime = 0;
            self.SyncTime = 0;

            for (int i = 0; i < self.QueuedMessage.Count; i++)
            {
                M2C_NoticeNumericMsg msg = (M2C_NoticeNumericMsg)self.QueuedMessage.Dequeue();
                msg?.Dispose();
            }

            foreach (var msg in self.OutPutMessageDict.Values)
            {
                msg?.Dispose();
            }

            self.OutPutMessageDict.Clear();
            self.OutPutMessageDict = default;
            self.QueuedMessage.Clear();
            self.QueuedMessage = default;
        }

        public static void Notice(this NumericNoticeComponent self, int numericType, long newValue)
        {
            if (self.LastSendTime > 0 && TimeInfo.Instance.ServerNow() - self.LastSendTime < 100)
            {
                self.AddQueueMessage(numericType, newValue);
                self.CheckSyneTimer();
            }
            else
            {
                self.NoticeImmediately(numericType, newValue);
            }
        }

        private static void AddQueueMessage(this NumericNoticeComponent self, int numericType, long newValue)
        {
            if (self.OutPutMessageDict.TryGetValue(numericType, out M2C_NoticeNumericMsg message))
            {
                message.NewValue = newValue;
            }
            else
            {
                message = M2C_NoticeNumericMsg.Create(true);
                message.NumericType = numericType;
                message.NewValue = newValue;

                self.OutPutMessageDict.Add(numericType, message);
                self.QueuedMessage.Enqueue(message);
            }
        }

        private static void CheckSyneTimer(this NumericNoticeComponent self)
        {
            if (self.SyncTime < TimeInfo.Instance.ServerNow())
            {
                if (self.SyncTimerId != 0)
                {
                    self.Root().GetComponent<TimerComponent>().Remove(ref self.SyncTimerId);
                }

                self.SyncTime = TimeInfo.Instance.ServerNow() + 100;
                self.SyncTimerId = self.Root().GetComponent<TimerComponent>().NewOnceTimer(self.SyncTime, TimerInvokeType.NumericSync, self);
            }
        }

        private static void NoticeQueueMsgImmediately(this NumericNoticeComponent self)
        {
            int queueCount = self.QueuedMessage.Count;
            if (queueCount == 0)
            {
                return;
            }

            Unit unit = self.Root().GetParent<Unit>();
            self.OutPutMessageDict.Clear();

            List<(int, long)> myNums = new();
            List<(int, long)> broadcastNums = new();
            for (int i = 0; i < queueCount; i++)
            {
                M2C_NoticeNumericMsg msg = (M2C_NoticeNumericMsg)self.QueuedMessage.Dequeue();

                myNums.Add((msg.NumericType, msg.NewValue));
                if (NumericType.Broadcast.Contains(msg.NumericType))
                {
                    broadcastNums.Add((msg.NumericType, msg.NewValue));
                }

                msg.Dispose();
            }

            self.LastSendTime = TimeInfo.Instance.ServerNow();

            if (myNums.Count > 0)
            {
                M2C_NoticeUnitNumericList message = M2C_NoticeUnitNumericList.Create(true);
                message.UnitId = unit.Id;
                foreach (var kv in myNums)
                {
                    message.NumericTypeList.Add(kv.Item1);
                    message.NewValueList.Add(kv.Item2);
                }

                MapMessageHelper.SendToClient(unit, message);
            }

            if (broadcastNums.Count > 0)
            {
                M2C_NoticeUnitNumericList message = M2C_NoticeUnitNumericList.Create(true);
                message.UnitId = unit.Id;
                foreach (var kv in myNums)
                {
                    message.NumericTypeList.Add(kv.Item1);
                    message.NewValueList.Add(kv.Item2);
                }

                MapMessageHelper.BroadcastExceptSelf(unit, message);
            }
        }

        private static void NoticeImmediately(this NumericNoticeComponent self, int numericType, long newValue)
        {
            Unit unit = self.GetParent<Unit>();
            M2C_NoticeUnitNumeric message = M2C_NoticeUnitNumeric.Create(true);
            message.UnitId = unit.Id;
            message.NumericType = numericType;
            message.NewValue = newValue;

            self.LastSendTime = TimeInfo.Instance.ServerNow();

            if (NumericType.Broadcast.Contains(numericType))
            {
                MapMessageHelper.Broadcast(unit, message);
            }
            else
            {
                MapMessageHelper.SendToClient(unit, message);
            }
        }
    }
}