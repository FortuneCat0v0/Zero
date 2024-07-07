using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    public enum EBuffType
    {
        /// <summary>
        /// 纯标记
        /// </summary>
        OnlySign = 0,
        ChangeNumeric,
    }

    public enum EBuffAddType
    {
        RefreshTime,
        CantOverlay,
        OverlayAddLayerRefreshTime,
        OnlyAddTime,
    }

    [ChildOf(typeof(BuffComponent))]
    public class Buff : Entity, IAwake, IAwake<int>, IDestroy, ITransfer, ISerializeToEntity
    {
        public int BuffConfigId { get; set; }

        public long StartTime { get; set; }

        public long NextTriggerTime { get; set; }

        public uint LayerCount { get; set; }

        [BsonIgnore]
        public Unit OwnerUnit => this.GetParent<BuffComponent>().GetParent<Unit>();

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