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

public sealed partial class EffectConfig: Bright.Config.BeanBase
{
    public EffectConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Desc = _buf.ReadString();
        AssetPath = _buf.ReadString();
        Life = _buf.ReadInt();
        EffectType = (EEffectType)_buf.ReadInt();
        BindPoint = _buf.ReadString();
        PostInit();
    }

    public static EffectConfig DeserializeEffectConfig(ByteBuf _buf)
    {
        return new EffectConfig(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Desc { get; private set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string AssetPath { get; private set; }
    /// <summary>
    /// 特效执行时间(毫秒)
    /// </summary>
    public int Life { get; private set; }
    /// <summary>
    /// 特效类型
    /// </summary>
    public EEffectType EffectType { get; private set; }
    /// <summary>
    /// 绑定位置
    /// </summary>
    public string BindPoint { get; private set; }

    public const int __ID__ = -682668973;
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
        + "Desc:" + Desc + ","
        + "AssetPath:" + AssetPath + ","
        + "Life:" + Life + ","
        + "EffectType:" + EffectType + ","
        + "BindPoint:" + BindPoint + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}