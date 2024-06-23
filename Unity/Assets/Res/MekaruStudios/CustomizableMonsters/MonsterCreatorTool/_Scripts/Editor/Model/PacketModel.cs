using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    [CreateAssetMenu(menuName = "MekaruStudios/MonsterCreator/Packet", fileName = "Packet", order = 0)]
    public class PacketModel : ScriptableObject, IPacketModel
    {
        [SerializeField]
        string _packetName;

        [SerializeField, HideInInspector]
        int _selectedEditorIndex;
        
        [SerializeField]
        UnitModel[] _units;

        public string GetPacketName()
        {
            return _packetName;
        }
        public IWindow GetCustomEditor()
        {
            var editorType = CustomizationEditorManager.CustomizationEditorTypes[_selectedEditorIndex];
            var adapter = (IWindowTemplate)Activator.CreateInstance(editorType);
            return adapter.Build();
        }
        public List<UnitModel> GetMonsterUnitModels()
        {
            return _units.ToList();
        }
    }
}
