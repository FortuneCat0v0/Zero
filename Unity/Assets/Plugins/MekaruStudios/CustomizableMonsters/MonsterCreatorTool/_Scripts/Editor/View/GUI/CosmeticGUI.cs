using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class CosmeticGUI : GUIDecorator, IWindowWidthObserver
    {
        Vector2 _scrollPos;
        float _windowWidth;

        public CosmeticGUI(IGUIComponent wrapped) : base(wrapped) { }

        public override void OnEnter()
        {
            base.OnEnter();
            var subject = (IWindowWidthSubject)ServiceLocator.Instance.Resolve<IMainWindow>();
            subject.RegisterObserver(this);
        }

        public override void OnExit()
        {
            base.OnExit();
            var subject = (IWindowWidthSubject)ServiceLocator.Instance.Resolve<IMainWindow>();
            subject.UnregisterObserver(this);
        }

        public override void Render()
        {
            base.Render();

            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            var units = ServiceLocator.Instance.Resolve<IUnitContainerModel>().GetUnits();

            foreach (var cosmeticModule in units.Select(unit => unit.CosmeticModule))
            {
                MonsterCreatorStyling.RenderButtonsInGrid(
                    cosmeticModule.GetCosmetics(),
                    .25f,
                    _windowWidth,
                    new Rectangle(75f, 75f),
                    cosmetic => CreateGUIContent(cosmetic.Prefab),
                    cosmetic => cosmeticModule.BindCosmetic(cosmetic)
                );

            }
            EditorGUILayout.EndScrollView();


        }
        static GUIContent CreateGUIContent(Object prefab)
        {
            return new GUIContent(AssetPreview.GetAssetPreview(prefab));
        }
        public void UpdateWidth(float width)
        {
            _windowWidth = width;
        }
    }
}
