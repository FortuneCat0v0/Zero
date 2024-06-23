using System;
using MekaruStudios.CustomizableMonsters;

namespace MekaruStudios.MonsterCreator
{
    public class WindowFactory : IWindowFactory
    {
        const string TYPE_ARGUMENT_EXCEPTION_MESSAGE =
            "Invalid window type name or type does not implement IWindow.";

        const string WIDTH_ARGUMENT_EXCEPTION_MESSAGE =
            "Invalid width percentage, width percentage must be in range of [0,1].";

        public IWindow GetWindow(string typeName, float widthPercentage)
        {
            if (widthPercentage is < 0 or > 1)
                throw new ArgumentException(WIDTH_ARGUMENT_EXCEPTION_MESSAGE);

            var unitContainerModel =
                ServiceLocator.Instance.Resolve<IUnitContainerModel>();

            var packetListController =
                ServiceLocator.Instance.Resolve<IPacketListController>();

            var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();

            switch (typeName)
            {
                case "empty":
                    return (Window)A.Window()
                        .WithWidthPercentage(widthPercentage)
                        .WithComponent(new GUIComponent());

                case "packetList":
                    return (Window)A.Window().WithWidthPercentage(widthPercentage)
                        .WithComponent(new PacketListGUI(packetListController));

                case "monsterUnitSelection":
                    return (Window)A.Window()
                        .WithWidthPercentage(widthPercentage)
                        .WithComponent(new UnitGUI(
                            new GUIComponent(),
                            packetListController,
                            new SingleUnitContainerController(unitContainerModel, previewEntityModel))
                        );
                case "base-material":
                    return (Window)A.Window()
                        .WithWidthPercentage(widthPercentage)
                        .WithComponent(new MaterialGUI(unitContainerModel, "Base", true));
                case "mouth-material":
                    return (Window)A.Window()
                        .WithWidthPercentage(widthPercentage)
                        .WithComponent(new MaterialGUI(unitContainerModel, "Mouth"));
                case "eye-material":
                    return (Window)A.Window()
                        .WithWidthPercentage(widthPercentage)
                        .WithComponent(new MaterialGUI(unitContainerModel, "Eye"));
                case "multi":
                    IGUIComponent gui = new GUIComponent();
                    gui = new MultiGUI(gui, packetListController, new MultipleUnitContainerController(unitContainerModel));
                    return (Window)A.Window()
                        .WithWidthPercentage(widthPercentage)
                        .WithComponent(gui);
                case "cosmetic":
                    return (Window)A.Window()
                        .WithWidthPercentage(widthPercentage)
                        .WithComponent(new CosmeticGUI(new GUIComponent()));


            }

            throw new ArgumentException(TYPE_ARGUMENT_EXCEPTION_MESSAGE);
        }
        public IWindow GetWindow(string typeName)
        {
            return GetWindow(typeName, .25f);
        }

        public IWindow GetWindow(Type type, float widthPercentage)
        {
            if (typeof(IWindow).IsAssignableFrom(type))
            {
                var window = (IWindow)Activator.CreateInstance(type);
                window.WidthPercentage = widthPercentage;
                return window;
            }

            throw new ArgumentException(TYPE_ARGUMENT_EXCEPTION_MESSAGE);
        }
    }
}
