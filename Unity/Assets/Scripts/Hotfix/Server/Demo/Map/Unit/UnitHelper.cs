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
            unitInfo.EUnitType = (int)unit.UnitType;
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

            SkillSComponent skillSComponent = unit.GetComponent<SkillSComponent>();
            if (skillSComponent != null)
            {
                List<EntityRef<SkillS>> skills = skillSComponent.GetAllSkill();
                foreach (SkillS skill in skills)
                {
                    unitInfo.SkillInfos.Add(skill.ToMessage());
                }

                foreach (KeyValuePair<int, int> keyValuePair in skillSComponent.SkillSlotDict)
                {
                    KeyValuePair_Int_Int keyValuePairIntInt = KeyValuePair_Int_Int.Create();
                    keyValuePairIntInt.Key = keyValuePair.Key;
                    keyValuePairIntInt.Value = keyValuePair.Value;
                    unitInfo.SkillGridDict.Add(keyValuePairIntInt);
                }
            }

            RoleCastComponent roleCastComponent = unit.GetComponent<RoleCastComponent>();
            if (roleCastComponent != null)
            {
                unitInfo.ERoleCamp = (int)roleCastComponent.RoleCamp;
            }

            return unitInfo;
        }

        // 获取看见unit的玩家，主要用于广播
        public static Dictionary<long, EntityRef<AOIEntity>> GetBeSeePlayers(this Unit self)
        {
            return self.GetComponent<AOIEntity>().GetBeSeePlayers();
        }

        public static async ETTask<(bool, Unit)> LoadUnit(Player player)
        {
            // 在Gate上动态创建一个Map Scene，把Unit从DB中加载放进来，然后传送到真正的Map中，这样登陆跟传送的逻辑就完全一样了
            GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
            gateMapComponent.Scene = await GateMapFactory.Create(gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");

            Unit unit = await UnitCacheHelper.GetUnitCache(player.Root(), gateMapComponent.Scene, player.Id);

            bool isNewUnit = unit == null;
            if (isNewUnit)
            {
                unit = UnitFactory.CreatePlayer(gateMapComponent.Scene, player.Id);
                unit.AddComponent<UnitDBSaveComponent>();
                List<Role> roles = await player.Root().GetComponent<DBManagerComponent>().GetZoneDB(StartSceneConfigCategory.Instance.Account.Zone)
                        .Query<Role>(d => d.Id == player.Id);
                unit.RoleName = roles[0].Name;

                UnitCacheHelper.AddOrUpdateUnitAllCache(unit);
            }
            else
            {
                if (unit.GetComponent<UnitDBSaveComponent>() == null)
                {
                    unit.AddComponent<UnitDBSaveComponent>();
                }
            }

            return (isNewUnit, unit);
        }
    }
}