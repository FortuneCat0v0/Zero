using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    public enum PopupTextType
    {
        Text_0 = 0,
        Text_1 = 1,
        Text_2 = 2,
    }

    public enum PopupTextLayer
    {
        Layer_0 = 0,
        Layer_1 = 1,
        Layer_2 = 2,
    }

    public enum PopupTextExecuteType
    {
        Type_0 = 0,
        Type_1 = 1,
    }

    public partial class PopupTextPanelComponent : Entity
    {
        public Camera MainCamera;
        public List<GameObject> ExecutingGameObjects = new();
    }
}