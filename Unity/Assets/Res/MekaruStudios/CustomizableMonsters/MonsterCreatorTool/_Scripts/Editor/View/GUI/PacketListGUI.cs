using System.Collections.Generic;
using System.Linq;
using MekaruStudios.CustomizableMonsters;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{
    public class PacketListGUI : IGUIComponent
    {
        public List<PacketModel> PacketList
        {
            get
            {
                return _packetList ??= _controller.GetAllPacketModels().ToList();
            }
        }


        Vector2 _scrollPos;
        List<PacketModel> _packetList;
        readonly IPacketListController _controller;

        public PacketListGUI(IPacketListController controller)
        {
            _controller = controller;
        }

        public void Render()
        {
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos);
            foreach (var packet in PacketList)
            {
                EditorGUILayout.BeginVertical();
                if (GUILayout.Button(packet.GetPacketName()))
                {
                    _controller.LoadCustomizationWindow(packet);
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.LabelField($"Monster Creator Version: v{Env.VERSION}");
            EditorGUILayout.EndScrollView();

        }
        public void OnEnter() { }
        public void OnExit() { }
    }
}
