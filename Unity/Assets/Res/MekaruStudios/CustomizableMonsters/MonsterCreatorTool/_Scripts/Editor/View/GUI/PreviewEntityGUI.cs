using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class PreviewEntityGUI : GUIDecorator, IPreviewEntityGUI, IPreviewEntityObserver
    {
        Editor _editor;
        GameObject _previewObject;


        public PreviewEntityGUI(IGUIComponent wrapped) 
            : base(wrapped)
        {
        }

        public void Reload()
        {
            if (_editor == null)
                return;
            
            _editor.ReloadPreviewInstances();
        }
        public override void OnEnter()
        {
            base.OnEnter();

            var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();
            previewEntityModel.RegisterObserver(this);
        }
        public override void OnExit()
        {
            base.OnExit();

            var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();
            previewEntityModel.RemoveRegister(this);

            if (_editor != null)
                Object.DestroyImmediate(_editor);
        }
        public void UpdatePreviewEntity(GameObject previewObject)
        {
            _previewObject = previewObject;
            Object.DestroyImmediate(_editor);
        }
        public override void Render()
        {
            _wrapped?.Render();

            var texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, new Color(.2f, .2f,.2f ));
            texture.Apply();
            var bgColor = new GUIStyle
            {
                normal =
                {
                    background = texture
                }
            };

            if (_previewObject != null)
            {
                if (_editor == null)
                    _editor = Editor.CreateEditor(_previewObject);

                _editor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(256, 256), bgColor);
            }
        }
    }
}
