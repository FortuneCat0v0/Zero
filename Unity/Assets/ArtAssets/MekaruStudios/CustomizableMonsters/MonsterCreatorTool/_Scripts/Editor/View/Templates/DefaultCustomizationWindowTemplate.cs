using MekaruStudios.MonsterCreator.Buttons;

namespace MekaruStudios.MonsterCreator
{
    [CustomizationEditor]
    public class DefaultCustomizationWindowTemplate : IWindowTemplate
    {
        public IWindow Build()
        {
            IGUIComponent gui = new GUIComponent();
            gui = new PreviewEntityGUI(gui);
            gui = new MonsterBtn(gui);
            gui = new WindowLoaderBtn(gui, "base-material", "Base Materials");
            gui = new WindowLoaderBtn(gui, "mouth-material", "Mouth Materials");
            gui = new WindowLoaderBtn(gui, "eye-material", "Eye Materials");
            gui = new WindowLoaderBtn(gui, "cosmetic", "Cosmetics");
            gui = new SaveBtn(gui, new FileSaver());
            gui = new DiscardBtn(gui);
            gui = new FooterGUI(gui);

            return (Window)A.Window()
                .WithWidthPercentage(.50f)
                .WithComponent(gui);
        }

    }

}
