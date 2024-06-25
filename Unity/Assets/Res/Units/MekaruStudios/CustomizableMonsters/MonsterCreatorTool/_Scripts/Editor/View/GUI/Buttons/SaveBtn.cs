using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator.Buttons
{
    public class SaveBtn : GUIDecorator
    {
        readonly IFileSaver _fileSaver;

        public SaveBtn(
            IGUIComponent wrapped,
            IFileSaver fileSaver
        ) : base(wrapped)
        {
            _fileSaver = fileSaver;
        }

        public override void Render()
        {
            base.Render();

            var originalColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.green;

            var btnStyle = new GUIStyle(GUI.skin.button)
            {
                fontStyle = FontStyle.Bold
            };

            if (GUILayout.Button("Save Monster as Prefab", btnStyle))
            {
                var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();
                var modelToSave = previewEntityModel.Get();
                FolderPanelGameObjectSaver.Save(modelToSave, _fileSaver);
            }

            GUI.backgroundColor = originalColor;
        }
    }
}
