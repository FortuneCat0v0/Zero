using System.Collections.Generic;
using MekaruStudios.MonsterCreator;

namespace MekaruStudios.CustomizableMonsters
{
    public interface IPacketListController
    {
        void LoadCustomizationWindow(IPacketModel model);
        IEnumerable<PacketModel> GetAllPacketModels();
        
        IPacketModel ActivePacketModel { get; }

    }
}
