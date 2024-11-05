using MongoDB.Bson.Serialization.Attributes;

namespace ET.Client
{
    [ChildOf(typeof(BuffCComponent))]
    public class BuffC : Entity, IAwake, IAwake<int>, IDestroy
    {
        public int BuffConfigId { get; set; }

        public long StartTime { get; set; }

        public long NextTriggerTime { get; set; }

        public uint LayerCount { get; set; }

        public Unit OwnerUnit => this.GetParent<BuffCComponent>().GetParent<Unit>();

        public long Timer;

        private BuffConfig buffConfig;

        public BuffConfig BuffConfig
        {
            get
            {
                return this.buffConfig ??= BuffConfigCategory.Instance.Get(this.BuffConfigId);
            }
        }
    }
}