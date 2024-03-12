namespace ET
{
    [ChildOf]
    public class AttributeEntry : Entity, IAwake, ISerializeToEntity
    {
        /// <summary>
        /// 词条数值属性类型
        /// </summary>
        public int Key;

        /// <summary>
        /// 词条数值属性值
        /// </summary>
        public long Value;

        /// <summary>
        /// 词条类型
        /// </summary>
        public EntryType EntryType;
    }
}