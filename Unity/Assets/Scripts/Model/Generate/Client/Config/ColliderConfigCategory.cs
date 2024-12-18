
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using System.Collections.Generic;

namespace ET
{
    [Config]
    public partial class ColliderConfigCategory : Singleton<ColliderConfigCategory>, IConfig
    {
        private readonly Dictionary<int, ColliderConfig> _dataMap;
        private readonly List<ColliderConfig> _dataList;

        public ColliderConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, ColliderConfig>();
            _dataList = new List<ColliderConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                ColliderConfig _v;
                _v = ColliderConfig.DeserializeColliderConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, ColliderConfig> DataMap => _dataMap;
        public List<ColliderConfig> DataList => _dataList;

        public ColliderConfig GetOrDefault(int key) => _dataMap.GetValueOrDefault(key);
        public ColliderConfig Get(int key)
        {
            if (_dataMap.TryGetValue(key,out var v))
            {
                return v;
            }
            ConfigLog.Error(this,key);
            return null;
        }

        public void ResolveRef()
        {
            foreach(var _v in _dataList)
            {
                _v.ResolveRef();
            }
        }

        partial void PostInit();
    }
}
