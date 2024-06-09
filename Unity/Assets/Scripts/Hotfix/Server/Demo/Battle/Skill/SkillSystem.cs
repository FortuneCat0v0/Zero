namespace ET.Server
{
    [EntitySystemOf(typeof(Skill))]
    [FriendOf(typeof(Skill))]
    public static partial class SkillSystem
    {
        [EntitySystem]
        private static void Awake(this Skill self)
        {
        }

        [EntitySystem]
        private static void Awake(this Skill self, int skillId, int skillLevel)
        {
            self.SkillConfigId = skillId;
            self.SkillLevel = skillLevel;
        }

        [EntitySystem]
        private static void Destroy(this Skill self)
        {
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
        }

        [EntitySystem]
        private static void Update(this Skill self)
        {
            if (self.SkillState == SkillState.Ready)
            {
                return;
            }

            if (self.SkillState == SkillState.Cooldown)
            {
                if (self.GetCurrentCD() <= 0)
                {
                    self.SkillState = SkillState.Ready;
                }

                return;
            }

            // 开始
            if (self.CurrentExecuteSkillConfig == null)
            {
                self.CurrentExecuteSkillIndex = 0;
                self.CurrentActionEventIndex = -1;
                self.NextActionEventIndex = 0;

                if (self.SkillConfig.Sub.Count > 0)
                {
                    self.CurrentExecuteSkillConfig =
                            SkillConfigCategory.Instance.Get(self.SkillConfig.Sub[self.CurrentExecuteSkillIndex], self.SkillLevel);
                }
                else
                {
                    self.CurrentExecuteSkillConfig = self.SkillConfig;
                }
            }

            long nowTime = TimeInfo.Instance.ClientNow();
            if (self.NextActionEventIndex >= self.CurrentExecuteSkillConfig.ActionEventsServer.Count)
            {
                if (self.SkillConfig.Sub.Count > 0)
                {
                    if (self.CurrentExecuteSkillIndex < self.SkillConfig.Sub.Count)
                    {
                        self.InputType = EInputType.Invaild;
                        self.CurrentExecuteSkillIndex++;
                        self.CurrentActionEventIndex = -1;
                        self.NextActionEventIndex = 0;
                        self.CurrentExecuteSkillConfig =
                                SkillConfigCategory.Instance.Get(self.SkillConfig.Sub[self.CurrentExecuteSkillIndex], self.SkillLevel);
                        self.SpellStartTime = nowTime;
                    }
                    else
                    {
                        self.EndSpell();
                        return;
                    }
                }
                else
                {
                    self.EndSpell();
                    return;
                }
            }

            if (nowTime > self.CurrentExecuteSkillConfig.Life + self.SpellStartTime)
            {
                self.EndSpell();
                return;
            }

            if (self.NextActionEventIndex <= self.CurrentActionEventIndex)
            {
                return;
            }

            string actionEventName = self.CurrentExecuteSkillConfig.ActionEventsServer[self.NextActionEventIndex];
            AActionEvent actionEvent = ActionEventDispatcherComponent.Instance.Get(actionEventName);

            if (actionEvent == null)
            {
                Log.Error($"not found actionEvent: {actionEventName}");
                return;
            }

            int triggerTime = self.CurrentExecuteSkillConfig.ActionEventTriggerPercentServer[self.NextActionEventIndex] / 100 * self.SkillConfig.Life;
            if (nowTime < self.SpellStartTime + triggerTime)
            {
                return;
            }

            bool ret = actionEvent.Check(self);
            if (ret == false)
            {
                return;
            }

            if (self.CancellationToken == null)
            {
                ETCancellationToken cancellationToken = new();
                self.CancellationToken = cancellationToken;
            }

            self.CurrentActionEventIndex = self.NextActionEventIndex;
            actionEvent.Execute(self, self.CancellationToken).Coroutine();
        }

        private static void Cancel(this Skill self)
        {
            self.CancellationToken?.Cancel();
            self.CancellationToken = null;
            self.CurrentExecuteSkillConfig = null;
            self.InputType = EInputType.Invaild;
        }

        public static void CancelSpell(this Skill self)
        {
            self.Cancel();

            self.SkillState = SkillState.Ready;
        }

        public static void EndSpell(this Skill self)
        {
            self.Cancel();

            self.SkillState = SkillState.Cooldown;
            self.SpellEndTime = TimeInfo.Instance.ClientNow();
        }

        public static bool StartSpell(this Skill self, EInputType inputType)
        {
            if (self.SkillState == SkillState.Ready)
            {
                if (self.SkillConfig.InputType == inputType)
                {
                    self.SpellStartTime = TimeInfo.Instance.ClientNow();
                    self.SkillState = SkillState.Active;
                    self.InputType = inputType;
                    return true;
                }
            }
            else if (self.SkillState == SkillState.Active)
            {
                if (self.CurrentExecuteSkillConfig.InputType == inputType)
                {
                    self.InputType = inputType;
                    return true;
                }
            }

            return false;
        }

        public static long GetCurrentCD(this Skill self)
        {
            return self.SpellEndTime + self.GetCD() - TimeInfo.Instance.ClientNow();
        }

        public static long GetCD(this Skill self)
        {
            // 这里可以加上减CD属性
            return self.SkillConfig.CD;
        }

        public static SkillInfo ToMessage(this Skill self)
        {
            SkillInfo skillInfo = SkillInfo.Create();
            skillInfo.Id = self.Id;
            skillInfo.SkillConfigId = self.SkillConfigId;
            skillInfo.SkillLevel = self.SkillLevel;
            skillInfo.SpellStartTime = self.SpellStartTime;
            skillInfo.SpellEndTime = self.SpellEndTime;

            return skillInfo;
        }
    }
}