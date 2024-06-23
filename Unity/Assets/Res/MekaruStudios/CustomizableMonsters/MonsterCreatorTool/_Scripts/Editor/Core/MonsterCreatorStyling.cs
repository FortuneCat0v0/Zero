using System;
using System.Collections.Generic;
using System.Linq;
using MekaruStudios.MonsterCreator;
using UnityEditor;
using UnityEngine;

namespace MekaruStudios.MonsterCreator
{

    public static class MonsterCreatorStyling
    {
        public static void RenderButtonsInGrid<T>(IEnumerable<T> items, float screenWidthPercentage, float windowWidth,
            Rectangle btnSize, Func<T, GUIContent> getGUIContent, Action<T> onBtnClicked)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (getGUIContent == null)
                throw new ArgumentNullException(nameof(getGUIContent));
            if (onBtnClicked == null)
                throw new ArgumentNullException(nameof(onBtnClicked));

            var width = windowWidth * screenWidthPercentage;
            var itemsPerRow = Mathf.Max(1, Mathf.FloorToInt(width / btnSize.Width));

            var itemList = items.ToArray();

            for (var i = 0; i < itemList.Length; i += itemsPerRow)
            {
                EditorGUILayout.BeginHorizontal();
                for (var j = i; j < Mathf.Min(i + itemsPerRow, itemList.Length); j++)
                {
                    var item = itemList[j];
                    if (GUILayout.Button(getGUIContent(item),
                        GUILayout.Width(btnSize.Width), GUILayout.Height(btnSize.Height)))
                    {
                        onBtnClicked(item);
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
        }

    }
}
