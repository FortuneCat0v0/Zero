//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;

namespace ET
{
   
[Config]
public partial class ColliderConfigCategory: ConfigSingleton<ColliderConfigCategory>
{
    private readonly Dictionary<int, ColliderConfig> _dataMap;
    private readonly List<ColliderConfig> _dataList;
    
    public ColliderConfigCategory(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, ColliderConfig>();
        _dataList = new List<ColliderConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            ColliderConfig _v;
            _v = ColliderConfig.DeserializeColliderConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public bool Contain(int id)
    {
        return _dataMap.ContainsKey(id);
    }

    public Dictionary<int, ColliderConfig> GetAll()
    {
        return _dataMap;
    }
    
    public List<ColliderConfig> DataList => _dataList;

    public ColliderConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public ColliderConfig Get(int key) => _dataMap[key];
    public ColliderConfig this[int key] => _dataMap[key];

    public override void Resolve(ConcurrentDictionary<Type, IConfigSingleton> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    public override void TrimExcess()
    {
        _dataMap.TrimExcess();
        _dataList.TrimExcess();
    }
    
    
    public override string ConfigName()
    {
        return typeof(ColliderConfig).Name;
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}