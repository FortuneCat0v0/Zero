using UnityEngine;

namespace ET.Client
{
    public enum EffectState
    {
        Waiting,
        Running,
        Finished
    }

    [ChildOf(typeof(EffectComponent))]
    public class Effect : Entity, IAwake<EffectData>, IDestroy
    {
        public EffectData EffectData;
        public EffectConfig EffectConfig;
        public EffectState EffectState;
        public long StartTime;
        public long Timer;
        public GameObject EffectGo;
        public Unit OwnerUnit => this.GetParent<EffectComponent>().GetParent<Unit>();
    }
}