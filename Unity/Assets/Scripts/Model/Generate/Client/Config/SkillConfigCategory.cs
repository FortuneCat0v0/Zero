
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
    public partial class SkillConfigCategory : Singleton<SkillConfigCategory>
    {
        private readonly List<SkillConfig> _dataList;

        private Dictionary<(int, int), SkillConfig> _dataMapUnion;

        public SkillConfigCategory(ByteBuf _buf)
        {
            _dataList = new List<SkillConfig>();

            for(int n = _buf.ReadSize() ; n > 0 ; --n)
            {
                SkillConfig _v;
                _v = SkillConfig.DeserializeSkillConfig(_buf);
                _dataList.Add(_v);
            }
            _dataMapUnion = new Dictionary<(int, int), SkillConfig>();
            foreach(var _v in _dataList)
            {
                _dataMapUnion.Add((_v.Id, _v.Level), _v);
            }
        }

        public List<SkillConfig> DataList => _dataList;

        public SkillConfig Get(int Id, int Level) => _dataMapUnion.TryGetValue((Id, Level), out SkillConfig __v) ? __v : null;

        partial void PostInit();
    }
}
