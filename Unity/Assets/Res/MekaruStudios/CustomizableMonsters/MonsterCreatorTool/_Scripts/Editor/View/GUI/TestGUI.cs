using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class TestGUI : GUIDecorator
    {
        public TestGUI(IGUIComponent wrapped) : base(wrapped) { }
        public override void Render()
        {
            base.Render();

            GUILayout.Label("TEST");
            GUILayout.BeginVertical();
            GUILayout.Button("NEW BUTTON");
            GUILayout.Button("NEW BUTTON");
            GUILayout.Button("NEW BUTTON");
            GUILayout.EndVertical();
        }
    }
}
