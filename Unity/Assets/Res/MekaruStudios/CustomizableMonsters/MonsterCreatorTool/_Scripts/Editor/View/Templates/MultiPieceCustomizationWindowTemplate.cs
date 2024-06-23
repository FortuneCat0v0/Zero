using MekaruStudios.MonsterCreator.Buttons;

namespace MekaruStudios.MonsterCreator
{

    [CustomizationEditor]
    public class MultiPieceCustomizationWindowTemplate : IWindowTemplate
    {
        public IWindow Build()
        {
            IGUIComponent gui = new GUIComponent();
            gui = new PreviewEntityGUI(gui);
            gui = new WindowLoaderBtn(gui, "multi", "Multi");
            gui = new SaveBtn(gui, new FileSaver());
            gui = new DiscardBtn(gui);
            gui = new FooterGUI(gui);
            
            return (Window)A.Window()
                .WithWidthPercentage(.50f)
                .WithComponent(gui);
        }
    }
}
