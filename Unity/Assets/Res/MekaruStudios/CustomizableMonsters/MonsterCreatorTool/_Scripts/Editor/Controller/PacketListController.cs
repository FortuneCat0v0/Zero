using System.Collections.Generic;
using System.Linq;
using MekaruStudios.MonsterCreator;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.CustomizableMonsters
{
    public class PacketListController : IPacketListController
    {
        public IPacketModel ActivePacketModel { get; private set; }
        
        IMainWindow _mainWindow;
        IPreviewEntityModel _previewEntityModel;


        public void LoadCustomizationWindow(IPacketModel model)
        {
            _mainWindow ??= ServiceLocator.Instance.Resolve<IMainWindow>();
            _previewEntityModel ??= ServiceLocator.Instance.Resolve<IPreviewEntityModel>();

            ActivePacketModel = model;
            
            _mainWindow.ReplaceWindow(model.GetCustomEditor(), 1);
            _previewEntityModel.NotifyObservers();
        }
        public IEnumerable<PacketModel> GetAllPacketModels()
        {
            var guids = AssetDatabase.FindAssets($"t:{nameof(PacketModel)}");
            return guids
                .Select(AssetDatabase.GUIDToAssetPath)
                .Select(AssetDatabase.LoadAssetAtPath<PacketModel>)
                .ToList();
        }
    }
}
