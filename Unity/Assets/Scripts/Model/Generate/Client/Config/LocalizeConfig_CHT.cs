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

public sealed partial class LocalizeConfig_CHT:  ALocalizeConfig 
{
    public LocalizeConfig_CHT(ByteBuf _buf)  : base(_buf) 
    {
        TextCHT = _buf.ReadString();
        PostInit();
    }

    public static LocalizeConfig_CHT DeserializeLocalizeConfig_CHT(ByteBuf _buf)
    {
        return new LocalizeConfig_CHT(_buf);
    }

    public string TextCHT { get; private set; }

    public const int __ID__ = -887446245;
    public override int GetTypeId() => __ID__;

    public override void Resolve(ConcurrentDictionary<Type, IConfigSingleton> _tables)
    {
        base.Resolve(_tables);
        PostResolve();
    }

    public override void TranslateText(System.Func<string, string, string> translator)
    {
        base.TranslateText(translator);
    }

    public override string ToString()
    {
        return "{ "
        + "Key:" + Key + ","
        + "TextCHT:" + TextCHT + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}
}