
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
    public partial class StartZoneConfigCategory : Singleton<StartZoneConfigCategory>, IConfig
    {
        private readonly Dictionary<int, StartZoneConfig> _dataMap;
        private readonly List<StartZoneConfig> _dataList;

        public StartZoneConfigCategory(ByteBuf _buf)
        {
            _dataMap = new Dictionary<int, StartZoneConfig>();
            _dataList = new List<StartZoneConfig>();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                StartZoneConfig _v;
                _v = StartZoneConfig.DeserializeStartZoneConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public Dictionary<int, StartZoneConfig> DataMap => _dataMap;
        public List<StartZoneConfig> DataList => _dataList;

        public StartZoneConfig GetOrDefault(int key) => _dataMap.GetValueOrDefault(key);
        public StartZoneConfig Get(int key)
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
