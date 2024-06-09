using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [FriendOf(typeof(MoveComponent))]
    [FriendOf(typeof(NumericComponent))]
    public static partial class UnitHelper
    {
        public static UnitInfo CreateUnitInfo(Unit unit)
        {
            UnitInfo unitInfo = UnitInfo.Create();
            unitInfo.UnitId = unit.Id;
            unitInfo.ConfigId = unit.ConfigId;
            unitInfo.Type = (int)unit.Type();
            unitInfo.Position = unit.Position;
            unitInfo.Forward = unit.Forward;

            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            if (moveComponent != null)
            {
                if (!moveComponent.IsArrived())
                {
                    unitInfo.MoveInfo = MoveInfo.Create();
                    unitInfo.MoveInfo.Points.Add(unit.Position);
                    for (int i = moveComponent.N; i < moveComponent.Targets.Count; ++i)
                    {
                        float3 pos = moveComponent.Targets[i];
                        unitInfo.MoveInfo.Points.Add(pos);
                    }
                }
            }

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            foreach ((int key, long value) in numericComponent.NumericDic)
            {
                unitInfo.KV.Add(key, value);
            }

            SkillComponent skillComponent = unit.GetComponent<SkillComponent>();
            if (skillComponent != null)
            {
                List<Skill> skills = skillComponent.GetAllSkill();
                foreach (Skill skill in skills)
                {
                    unitInfo.SkillInfos.Add(skill.ToMessage());
                }

                foreach (KeyValuePair<int, int> keyValuePair in skillComponent.SkillGridDict)
                {
                    KeyValuePair_Int_Int keyValuePairIntInt = KeyValuePair_Int_Int.Create();
                    keyValuePairIntInt.Key = keyValuePair.Key;
                    keyValuePairIntInt.Value = keyValuePair.Value;
                    unitInfo.SkillGridDict.Add(keyValuePairIntInt);
                }
            }

            return unitInfo;
        }

        // 获取看见unit的玩家，主要用于广播
        public static Dictionary<long, EntityRef<AOIEntity>> GetBeSeePlayers(this Unit self)
        {
            return self.GetComponent<AOIEntity>().GetBeSeePlayers();
        }

        /// <summary>
        /// 给Player添加GateMapComponent组件，并创建一个Map Scene赋值给GateMapComponent组件。从缓存服获取Unit挂载在Map Scene下，如果查询不到，
        /// 则创建一个Unit,并更新到UnitCache服上
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static async ETTask<(bool, Unit)> LoadUnit(Player player)
        {
            // 在Gate上动态创建一个Map Scene，把Unit从DB中加载放进来，然后传送到真正的Map中，这样登陆跟传送的逻辑就完全一样了
            GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
            gateMapComponent.Scene =
                    await GateMapFactory.Create(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");

            Unit unit = await UnitCacheHelper.GetUnitCache(gateMapComponent.Scene, player.Id);

            bool isNewUnit = unit == null;
            if (isNewUnit)
            {
                unit = UnitFactory.CreatePlayer(gateMapComponent.Scene, player.Id);

                // List<Role> roles = await player.Root().GetComponent<DBManagerComponent>().GetZoneDB(player.Zone()).Query<Role>(d => d.Id == player.Id);
                // unit.AddComponent(roleList[0]);

                UnitCacheHelper.AddOrUpdateUnitAllCache(unit);
            }

            return (isNewUnit, unit);
        }
    }
}