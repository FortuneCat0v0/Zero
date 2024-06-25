using MekaruStudios.CustomizableMonsters;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class DependencyLoader
    {
        public static void LoadDependencies()
        {
            ServiceLocator.Instance.Provide<IUnitContainerModel>(new UnitContainerModel());
            
            ServiceLocator.Instance.Provide<IPacketListController>(new PacketListController());
            
            ServiceLocator.Instance.Provide<IPreviewEntityModel>(new PreviewEntityModel());
            ServiceLocator.Instance.Provide<IWindowFactory>(new WindowFactory());
            
            var window = (MainWindow)new MainWindowFactory().GetWindow("default");
            ServiceLocator.Instance.Provide<IMainWindow>(window);
        }

    }
}
