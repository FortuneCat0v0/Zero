using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class FooterGUI : GUIDecorator
    {

        public FooterGUI(IGUIComponent wrapped) : base(wrapped) { }

        public override void Render()
        {
            base.Render();

            var linkStyle = new GUIStyle(GUI.skin.label);
            linkStyle.normal.textColor = Color.gray;
            linkStyle.hover.textColor = Color.cyan;
            linkStyle.active.textColor = Color.yellow;
            linkStyle.alignment = TextAnchor.MiddleCenter;
            linkStyle.wordWrap = true;

            if (GUILayout.Button("Need any help? Contact us from our discord channel!", linkStyle))
                Application.OpenURL("https://www.discord.gg/Zf5kDUzYfq");
        }
    }
}
