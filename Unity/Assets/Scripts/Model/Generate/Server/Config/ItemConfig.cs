using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class ItemConfigCategory : Singleton<ItemConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, ItemConfig> dict = new();
		
        public void Merge(object o)
        {
            ItemConfigCategory s = o as ItemConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public ItemConfig Get(int id)
        {
            this.dict.TryGetValue(id, out ItemConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (ItemConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, ItemConfig> GetAll()
        {
            return this.dict;
        }

        public ItemConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class ItemConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>名字</summary>
		public string Name { get; set; }
		/// <summary>类型</summary>
		public int Type { get; set; }
		/// <summary>装备装配部位</summary>
		public int EquipPosition { get; set; }
		/// <summary>UI图片</summary>
		public string Icon { get; set; }
		/// <summary>世界图片</summary>
		public string OnWorldSprite { get; set; }
		/// <summary>描述</summary>
		public string Description { get; set; }
		/// <summary>使用半径</summary>
		public int UseRadius { get; set; }
		/// <summary>能否拾取</summary>
		public int CanPickedUp { get; set; }
		/// <summary>能否丢下</summary>
		public int CanDropped { get; set; }
		/// <summary>能否携带</summary>
		public int CanCarried { get; set; }
		/// <summary>价格</summary>
		public int Price { get; set; }
		/// <summary>百分率</summary>
		public int SellPercentage { get; set; }
		/// <summary>体积</summary>
		public int volume { get; set; }

	}
}