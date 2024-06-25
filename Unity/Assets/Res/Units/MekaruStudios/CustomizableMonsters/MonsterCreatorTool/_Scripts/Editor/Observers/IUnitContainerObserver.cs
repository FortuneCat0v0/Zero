using System.Collections.Generic;

namespace MekaruStudios.MonsterCreator
{
    public interface IUnitContainerObserver
    {
        void UpdateMonsterUnitStorage(List<IUnitModel> monsterUnitModels);
    }
}
