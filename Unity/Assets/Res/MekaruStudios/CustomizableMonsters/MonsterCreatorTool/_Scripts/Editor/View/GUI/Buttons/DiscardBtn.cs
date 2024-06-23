using UnityEngine;

namespace MekaruStudios.MonsterCreator.Buttons
{
    public class DiscardBtn : GUIDecorator
    {
        public DiscardBtn(IGUIComponent wrapped) : base(wrapped) { }

        public override void Render()
        {
            base.Render();

            var originalColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.red;

            var btnStyle = new GUIStyle(GUI.skin.button)
            {
                fontStyle = FontStyle.Bold
            };

            if (GUILayout.Button("Discard Changes", btnStyle))
            {
                var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();
                var unitContainerModel = ServiceLocator.Instance.Resolve<IUnitContainerModel>();
                
                previewEntityModel.Destroy();
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                previewEntityModel.Create(cube);
                Object.DestroyImmediate(cube);
                previewEntityModel.NotifyObservers();
                unitContainerModel.Clear();
            }

            GUI.backgroundColor = originalColor;
        }
    }
}
