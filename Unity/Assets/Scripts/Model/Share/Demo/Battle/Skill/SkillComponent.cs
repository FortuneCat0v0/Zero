﻿using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    namespace EventType
    {
        public struct ActionEventData
        {
            public EActionEventType actionEventType;
            public Unit owner;

            public Unit target;
            //技能数据来源放在此处，如果有技能编辑器，对接编辑器数据；如果是表格配置技能数据则来源表格。
        }
    }

    [ComponentOf(typeof(Unit))]
    public class SkillComponent : Entity, IAwake, IDestroy, IDeserialize, ITransfer
    {
        [BsonIgnore]
        public Unit Unit => this.GetParent<Unit>();

        [BsonIgnore]
        public Dictionary<int, long> IdSkillMap = new();

        [BsonIgnore]
        public Dictionary<ESkillAbstractType, List<long>> AbstractTypeSkills = new();

        /// <summary>
        /// 容器-技能
        /// </summary>
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<int, long> SkillGridMap = new();
    }
}