using MongoDB.Bson.Serialization.Attributes;

namespace ET.Server
{
    [ChildOf(typeof(BuffSComponent))]
    public class BuffS : Entity, IAwake, IAwake<int>, IDestroy, ITransfer, ISerializeToEntity
    {
        public int BuffConfigId { get; set; }

        public long StartTime { get; set; }

        public long NextTriggerTime { get; set; }

        public uint LayerCount { get; set; }

        [BsonIgnore]
        public Unit OwnerUnit => this.GetParent<BuffSComponent>().GetParent<Unit>();

        [BsonIgnore]
        public long Timer;

        [BsonIgnore]
        private BuffConfig buffConfig;

        [BsonIgnore]
        public BuffConfig BuffConfig
        {
            get
            {
                return this.buffConfig ??= BuffConfigCategory.Instance.Get(this.BuffConfigId);
            }
        }
    }
}