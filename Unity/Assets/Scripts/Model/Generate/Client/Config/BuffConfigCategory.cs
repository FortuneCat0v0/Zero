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
public partial class BuffConfigCategory: ConfigSingleton<BuffConfigCategory>
{
    private readonly Dictionary<int, BuffConfig> _dataMap;
    private readonly List<BuffConfig> _dataList;
    
    public BuffConfigCategory(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, BuffConfig>();
        _dataList = new List<BuffConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            BuffConfig _v;
            _v = BuffConfig.DeserializeBuffConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }
    
    public bool Contain(int id)
    {
        return _dataMap.ContainsKey(id);
    }

    public Dictionary<int, BuffConfig> GetAll()
    {
        return _dataMap;
    }
    
    public List<BuffConfig> DataList => _dataList;

    public BuffConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public BuffConfig Get(int key) => _dataMap[key];
    public BuffConfig this[int key] => _dataMap[key];

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
        return typeof(BuffConfig).Name;
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}