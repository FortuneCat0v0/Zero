using System;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [Invoke(TimerInvokeType.EffectTimer)]
    public class EffectTimer : ATimer<Effect>
    {
        protected override void Run(Effect self)
        {
            try
            {
                self.Update();
            }
            catch (Exception e)
            {
                Log.Error($"move timer error: {self.Id}\n{e}");
            }
        }
    }

    [FriendOf(typeof(Effect))]
    [EntitySystemOf(typeof(Effect))]
    public static partial class EffectSystem
    {
        [EntitySystem]
        private static void Awake(this Effect self, EffectData effectData)
        {
            self.EffectData = effectData;
            self.EffectConfig = EffectConfigCategory.Instance.Get(effectData.EffectConfigId);

            self.StartTime = TimeInfo.Instance.ServerNow();
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.EffectTimer, self);
            self.EffectGo = GameObjectPoolHelper.GetObjectFromPoolSync(self.Scene(), AssetPathHelper.GetEffectPath(self.EffectConfig.AssetPath));
        }

        [EntitySystem]
        private static void Destroy(this Effect self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            GameObjectPoolHelper.ReturnObjectToPool(self.EffectGo);
        }

        public static void Update(this Effect self)
        {
            switch (self.EffectState)
            {
                case EffectState.Waiting:
                {
                    switch (self.EffectConfig.EffectType)
                    {
                        case EEffectType.Normal:
                        {
                            self.EffectGo.transform.SetParent(self.Root().GetComponent<GlobalComponent>().Unit);
                            self.EffectGo.transform.position = self.EffectData.Position;
                            self.EffectGo.transform.localScale = Vector3.one;
                            self.EffectGo.transform.rotation = quaternion.RotateY(self.EffectData.Angle);
                            break;
                        }
                        case EEffectType.BindUnit:
                        {
                            self.EffectGo.transform.SetParent(self.OwnerUnit.GetComponent<GameObjectComponent>().UnitGo.transform);
                            self.EffectGo.transform.localPosition = Vector3.zero;
                            self.EffectGo.transform.localScale = Vector3.one;
                            break;
                        }
                        case EEffectType.FollowUnit:
                        {
                            self.EffectGo.transform.SetParent(self.Root().GetComponent<GlobalComponent>().Unit);
                            self.EffectGo.transform.position = self.EffectData.Position;
                            self.EffectGo.transform.localScale = Vector3.one;
                            self.EffectGo.transform.rotation = quaternion.RotateY(self.EffectData.Angle);
                            break;
                        }
                    }

                    self.EffectState = EffectState.Running;

                    break;
                }
                case EffectState.Running:
                {
                    long timeNow = TimeInfo.Instance.ServerNow();
                    if (timeNow > self.StartTime + self.EffectConfig.Life)
                    {
                        self.EffectState = EffectState.Finished;
                        return;
                    }

                    switch (self.EffectConfig.EffectType)
                    {
                        case EEffectType.Normal:
                        {
                            break;
                        }
                        case EEffectType.BindUnit:
                        {
                            break;
                        }
                        case EEffectType.FollowUnit:
                        {
                            // 执行跟随
                            break;
                        }
                    }

                    break;
                }
                case EffectState.Finished:
                {
                    self.Dispose();
                    break;
                }
            }
        }
    }
}