using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 摇杆
    /// </summary>
    [ComponentOf(typeof(UIMainComponent))]
    public class UIJoystickComponent : Entity, IAwake<GameObject>, IFixedUpdate
    {
        public GameObject GameObject;
        public GameObject StartArea;
        public GameObject Joystick;
        public GameObject JoystickBottom;
        public GameObject PositionFocus0;
        public GameObject PositionFocus1;
        public GameObject PositionFocus2;
        public GameObject PositionFocus3;
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
        public int OperateModel; // 0固定 1移动
        public float Radius; // 摇杆按钮移动的半径

        public Vector3 Direction; // 方向单位向量
        public Vector3 LastDirection;
        public Vector3 Target;
        public bool IsDrag;
        public float3 LastUnitPosition;
    }
}