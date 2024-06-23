using System.Collections.Generic;

namespace MekaruStudios.MonsterCreator
{
    public interface IPacketModel
    {
        string GetPacketName();
        IWindow GetCustomEditor();
        List<UnitModel> GetMonsterUnitModels();
    }
}
