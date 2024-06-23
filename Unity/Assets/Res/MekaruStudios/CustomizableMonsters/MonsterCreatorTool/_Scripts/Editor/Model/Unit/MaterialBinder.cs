using System;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public static class MaterialBinder
    {
        public static void Bind(Material material, string childTransformPathToBind)
        {
            var renderer = GetTargetRenderer(childTransformPathToBind);
            renderer.gameObject.SetActive(material != null);
            renderer.material = material;
            var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();
            previewEntityModel.NotifyObservers();
        }

        static Renderer GetTargetRenderer(string childTransformPathToBind)
        {
            var previewEntityModel = ServiceLocator.Instance.Resolve<IPreviewEntityModel>();
            var target = previewEntityModel.Get();
            
            if (target == null)
                throw new NullReferenceException("Target gameObject is null");

            var targetChildTransformToBind = target.transform.Find(childTransformPathToBind);

            if (targetChildTransformToBind == null)
                throw new ArgumentException("Given transform path for material binding is not exist.");

            var renderer = targetChildTransformToBind.GetComponent<Renderer>();
            return renderer;
        }
    }
}
