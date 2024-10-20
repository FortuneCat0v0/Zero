
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
    [EnableClass]
    public sealed partial class BuffConfig : BeanBase
    {
        public BuffConfig(ByteBuf _buf)
        {
            Id = _buf.ReadInt();
            Name = _buf.ReadString();
            Desc = _buf.ReadString();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);StartAEs = new System.Collections.Generic.List<string>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { string _e0;  _e0 = _buf.ReadString(); StartAEs.Add(_e0);}}
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);StartAEParams = new System.Collections.Generic.List<System.Collections.Generic.List<int>>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { System.Collections.Generic.List<int> _e0;  {int n1 = System.Math.Min(_buf.ReadSize(), _buf.Size);_e0 = new System.Collections.Generic.List<int>(n1);for(var i1 = 0 ; i1 < n1 ; i1++) { int _e1;  _e1 = _buf.ReadInt(); _e0.Add(_e1);}} StartAEParams.Add(_e0);}}
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);EndAEs = new System.Collections.Generic.List<string>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { string _e0;  _e0 = _buf.ReadString(); EndAEs.Add(_e0);}}
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);EndAEParams = new System.Collections.Generic.List<System.Collections.Generic.List<int>>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { System.Collections.Generic.List<int> _e0;  {int n1 = System.Math.Min(_buf.ReadSize(), _buf.Size);_e0 = new System.Collections.Generic.List<int>(n1);for(var i1 = 0 ; i1 < n1 ; i1++) { int _e1;  _e1 = _buf.ReadInt(); _e0.Add(_e1);}} EndAEParams.Add(_e0);}}
            Duration = _buf.ReadInt();
            TriggerInterval = _buf.ReadInt();
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);IntervalAEs = new System.Collections.Generic.List<string>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { string _e0;  _e0 = _buf.ReadString(); IntervalAEs.Add(_e0);}}
            {int n0 = System.Math.Min(_buf.ReadSize(), _buf.Size);IntervalAEParams = new System.Collections.Generic.List<System.Collections.Generic.List<int>>(n0);for(var i0 = 0 ; i0 < n0 ; i0++) { System.Collections.Generic.List<int> _e0;  {int n1 = System.Math.Min(_buf.ReadSize(), _buf.Size);_e0 = new System.Collections.Generic.List<int>(n1);for(var i1 = 0 ; i1 < n1 ; i1++) { int _e1;  _e1 = _buf.ReadInt(); _e0.Add(_e1);}} IntervalAEParams.Add(_e0);}}
            MaxLayer = _buf.ReadInt();
            Goup = _buf.ReadInt();

            PostInit();
        }

        public static BuffConfig DeserializeBuffConfig(ByteBuf _buf)
        {
            return new BuffConfig(_buf);
        }

        /// <summary>
        /// buffID
        /// </summary>
        public readonly int Id;

        /// <summary>
        /// 名称
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// 备注
        /// </summary>
        public readonly string Desc;

        /// <summary>
        /// 开始事件
        /// </summary>
        public readonly System.Collections.Generic.List<string> StartAEs;

        /// <summary>
        /// 开始事件参数
        /// </summary>
        public readonly System.Collections.Generic.List<System.Collections.Generic.List<int>> StartAEParams;

        /// <summary>
        /// 结束事件
        /// </summary>
        public readonly System.Collections.Generic.List<string> EndAEs;

        /// <summary>
        /// 结束事件参数
        /// </summary>
        public readonly System.Collections.Generic.List<System.Collections.Generic.List<int>> EndAEParams;

        /// <summary>
        /// 持续时间
        /// </summary>
        public readonly int Duration;

        /// <summary>
        /// 触发间隔
        /// </summary>
        public readonly int TriggerInterval;

        /// <summary>
        /// 间隔事件
        /// </summary>
        public readonly System.Collections.Generic.List<string> IntervalAEs;

        /// <summary>
        /// 间隔事件参数
        /// </summary>
        public readonly System.Collections.Generic.List<System.Collections.Generic.List<int>> IntervalAEParams;

        /// <summary>
        /// 最大叠加层数
        /// </summary>
        public readonly int MaxLayer;

        /// <summary>
        /// 分组
        /// </summary>
        public readonly int Goup;


        public const int __ID__ = -1370631787;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef()
        {
            
            
            
            
            
            
            
            
            
            
            
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "Id:" + Id + ","
            + "Name:" + Name + ","
            + "Desc:" + Desc + ","
            + "StartAEs:" + Luban.StringUtil.CollectionToString(StartAEs) + ","
            + "StartAEParams:" + Luban.StringUtil.CollectionToString(StartAEParams) + ","
            + "EndAEs:" + Luban.StringUtil.CollectionToString(EndAEs) + ","
            + "EndAEParams:" + Luban.StringUtil.CollectionToString(EndAEParams) + ","
            + "Duration:" + Duration + ","
            + "TriggerInterval:" + TriggerInterval + ","
            + "IntervalAEs:" + Luban.StringUtil.CollectionToString(IntervalAEs) + ","
            + "IntervalAEParams:" + Luban.StringUtil.CollectionToString(IntervalAEParams) + ","
            + "MaxLayer:" + MaxLayer + ","
            + "Goup:" + Goup + ","
            + "}";
        }

        partial void PostInit();
    }
}
