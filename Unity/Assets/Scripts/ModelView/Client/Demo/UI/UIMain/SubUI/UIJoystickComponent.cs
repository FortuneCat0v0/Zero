﻿using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    public enum EJoystickModel
    {
        Fixed,
        Free
    }

    /// <summary>
    /// 摇杆
    /// </summary>
    [ComponentOf(typeof(UIMainComponent))]
    public class UIJoystickComponent : Entity, IAwake<GameObject>, IUpdate
    {
        public GameObject GameObject;
        public GameObject StartArea;
        public GameObject Joystick;
        public GameObject JoystickBottom;
        public GameObject PositionFocus;
        public GameObject JoystickThumb;

        public Image JoystickBottomImg;
        public Image JoystickThumbImg;
        public RectTransform RectTransform;

        public Camera UICamera;
        public Camera MainCamera;
        public Unit MyUnit { get; set; }
        public MoveComponent MoveComponent { get; set; }
        public ClientSenderComponent ClientSenderComponent { get; set; }

        public int MapMask;
        public Vector2 OldPoint;
        public Vector2 NewPoint;
        public EJoystickModel JoystickModel;
        public float Radius; // 摇杆按钮移动的半径

        public Vector3 Direction; // 方向单位向量
        public Vector3 LastDirection;
        public Vector3 Target;
        public bool IsDrag;
        public float3 LastUnitPosition;
    }
}