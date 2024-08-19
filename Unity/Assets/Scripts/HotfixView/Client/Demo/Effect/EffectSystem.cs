using System;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Effect))]
    [EntitySystemOf(typeof(Effect))]
    public static partial class EffectSystem
    {
        [EntitySystem]
        private static void Awake(this Effect self, EffectData effectData)
        {
            self.EffectData = effectData;
            self.EffectConfig = EffectConfigCategory.Instance.Get(effectData.EffectConfigId);

            self.EffectGo = GameObjectPoolHelper.GetObjectFromPoolSync(self.Scene(), AssetPathHelper.GetEffectPath(self.EffectConfig.AssetPath));

            if (self.EffectConfig.Life > 0)
            {
                self.AddComponent<TimeoutComponent, long>(self.EffectConfig.Life);
            }

            if (self.EffectConfig.FollowUnit)
            {
                self.EffectGo.transform.SetParent(self.OwnerUnit.GetComponent<GameObjectComponent>().GameObject.transform);
                self.EffectGo.transform.localPosition = Vector3.zero;
                self.EffectGo.transform.localScale = Vector3.one;
            }
            else
            {
                self.EffectGo.transform.SetParent(self.Root().GetComponent<GlobalComponent>().Unit);
                self.EffectGo.transform.position = self.EffectData.Position;
                self.EffectGo.transform.localScale = Vector3.one;
                self.EffectGo.transform.rotation = quaternion.Euler(0, math.radians(self.EffectData.Angle), 0);
            }
        }

        [EntitySystem]
        private static void Destroy(this Effect self)
        {
            GameObjectPoolHelper.ReturnObjectToPool(self.EffectGo);
        }
    }
}