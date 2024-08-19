using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof(EffectComponent))]
    public class Effect : Entity, IAwake<EffectData>, IDestroy
    {
        public EffectData EffectData;
        public EffectConfig EffectConfig;
        public GameObject EffectGo;
        public Unit OwnerUnit => this.GetParent<EffectComponent>().GetParent<Unit>();
    }
}