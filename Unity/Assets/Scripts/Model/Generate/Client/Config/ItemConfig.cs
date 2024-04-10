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

public sealed partial class ItemConfig: Bright.Config.BeanBase
{
    public ItemConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        Type = _buf.ReadInt();
        EquipPosition = _buf.ReadInt();
        Quality = _buf.ReadInt();
        Icon = _buf.ReadString();
        Description = _buf.ReadString();
        PostInit();
    }

    public static ItemConfig DeserializeItemConfig(ByteBuf _buf)
    {
        return new ItemConfig(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public int Type { get; private set; }
    public int EquipPosition { get; private set; }
    public int Quality { get; private set; }
    public string Icon { get; private set; }
    public string Description { get; private set; }

    public const int __ID__ = -764023723;
    public override int GetTypeId() => __ID__;

    public  void Resolve(ConcurrentDictionary<Type, IConfigSingleton> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "Type:" + Type + ","
        + "EquipPosition:" + EquipPosition + ","
        + "Quality:" + Quality + ","
        + "Icon:" + Icon + ","
        + "Description:" + Description + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}