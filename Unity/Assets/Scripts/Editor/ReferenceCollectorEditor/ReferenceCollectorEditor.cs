using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
//Object并非C#基础中的Object，而是 UnityEngine.Object
using Object = UnityEngine.Object;

//自定义ReferenceCollector类在界面中的显示与功能
[CustomEditor(typeof(ReferenceCollector))]
public class ReferenceCollectorEditor : Editor
{
    //输入在textfield中的字符串
    private string searchKey
    {
        get
        {
            return _searchKey;
        }
        set
        {
            if (_searchKey != value)
            {
                _searchKey = value;
                heroPrefab = referenceCollector.Get<Object>(searchKey);
            }
        }
    }

    private ReferenceCollector referenceCollector;

    private Object heroPrefab;

    private string _searchKey = "";

    private ReorderableList reorderableList;

    List<int> delList = new();

    private void DelNullReference()
    {
        var dataProperty = serializedObject.FindProperty("data");
        for (int i = dataProperty.arraySize - 1; i >= 0; i--)
        {
            var gameObjectProperty = dataProperty.GetArrayElementAtIndex(i).FindPropertyRelative("gameObject");
            if (gameObjectProperty.objectReferenceValue == null)
            {
                dataProperty.DeleteArrayElementAtIndex(i);
                EditorUtility.SetDirty(referenceCollector);
                serializedObject.ApplyModifiedProperties();
                serializedObject.UpdateIfRequiredOrScript();
            }
        }
    }

    private void OnEnable()
    {
        //将被选中的gameobject所挂载的ReferenceCollector赋值给编辑器类中的ReferenceCollector，方便操作
        referenceCollector = (ReferenceCollector)target;

        var dataProperty = serializedObject.FindProperty("data");

        reorderableList = new ReorderableList(serializedObject, dataProperty, true, true, true, true)
        {
            drawHeaderCallback = (Rect rect) => { EditorGUI.LabelField(rect, "References"); },

            drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var element = dataProperty.GetArrayElementAtIndex(index);
                var keyProperty = element.FindPropertyRelative("key");
                var gameObjectProperty = element.FindPropertyRelative("gameObject");

                EditorGUI.PropertyField(new Rect(rect.x, rect.y, 150, EditorGUIUtility.singleLineHeight), keyProperty, GUIContent.none);
                EditorGUI.PropertyField(new Rect(rect.x + 155, rect.y, rect.width - 180, EditorGUIUtility.singleLineHeight), gameObjectProperty,
                    GUIContent.none);
                if (GUI.Button(new Rect(rect.x + rect.width - 25, rect.y, 25, EditorGUIUtility.singleLineHeight), "X"))
                {
                    this.delList.Add(index);
                }
            },

            // onAddCallback = (ReorderableList list) => { AddReference(dataProperty, Guid.NewGuid().GetHashCode().ToString(), null); },

            // onRemoveCallback = (ReorderableList list) => { dataProperty.DeleteArrayElementAtIndex(list.index); }
        };
    }

    public override void OnInspectorGUI()
    {
        //使ReferenceCollector支持撤销操作，还有Redo，不过没有在这里使用
        Undo.RecordObject(referenceCollector, "Changed Settings");
        var dataProperty = serializedObject.FindProperty("data");
        //开始水平布局，如果是比较新版本学习U3D的，可能不知道这东西，这个是老GUI系统的知识，除了用在编辑器里，还可以用在生成的游戏中
        GUILayout.BeginHorizontal();
        //下面几个if都是点击按钮就会返回true调用里面的东西
        if (GUILayout.Button("添加引用"))
        {
            //添加新的元素，具体的函数注释
            // Guid.NewGuid().GetHashCode().ToString() 就是新建后默认的key
            AddReference(dataProperty, Guid.NewGuid().GetHashCode().ToString(), null);
        }

        if (GUILayout.Button("全部删除"))
        {
            referenceCollector.Clear();
            this.delList.Clear();
        }

        if (GUILayout.Button("删除空引用"))
        {
            DelNullReference();
            this.delList.Clear();
        }

        if (GUILayout.Button("排序"))
        {
            referenceCollector.Sort();
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        //可以在编辑器中对searchKey进行赋值，只要输入对应的Key值，就可以点后面的删除按钮删除相对应的元素
        searchKey = EditorGUILayout.TextField(searchKey);
        //添加的可以用于选中Object的框，这里的object也是(UnityEngine.Object
        //第三个参数为是否只能引用scene中的Object
        EditorGUILayout.ObjectField(heroPrefab, typeof(Object), false);
        if (GUILayout.Button("删除"))
        {
            referenceCollector.Remove(searchKey);
            heroPrefab = null;
            this.delList.Clear();
        }

        GUILayout.EndHorizontal();
        EditorGUILayout.Space();

        var eventType = Event.current.type;
        //在Inspector 窗口上创建区域，向区域拖拽资源对象，获取到拖拽到区域的对象
        if (eventType == EventType.DragUpdated || eventType == EventType.DragPerform)
        {
            // Show a copy icon on the drag
            DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

            if (eventType == EventType.DragPerform)
            {
                DragAndDrop.AcceptDrag();
                foreach (var o in DragAndDrop.objectReferences)
                {
                    AddReference(dataProperty, o.name, o);
                }
            }

            Event.current.Use();
        }

        //遍历删除list，将其删除掉
        for (int i = delList.Count - 1; i >= 0; i--)
        {
            dataProperty.DeleteArrayElementAtIndex(delList[i]);
        }
        this.delList.Clear();

        reorderableList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
        serializedObject.UpdateIfRequiredOrScript();
    }

    //添加元素，具体知识点在ReferenceCollector中说了
    private void AddReference(SerializedProperty dataProperty, string key, Object obj)
    {
        int index = dataProperty.arraySize;
        dataProperty.InsertArrayElementAtIndex(index);
        var element = dataProperty.GetArrayElementAtIndex(index);
        element.FindPropertyRelative("key").stringValue = key;
        element.FindPropertyRelative("gameObject").objectReferenceValue = obj;
    }
}