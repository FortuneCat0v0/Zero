using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    /// <summary>
    /// 摇杆
    /// </summary>
    [ComponentOf(typeof(UIMainComponent))]
    public class UIJoystickComponent : Entity, IAwake<GameObject>, IDestroy
    {
        public GameObject GameObject;
        public GameObject StartArea;
        public GameObject Joystick;
        public GameObject JoystickBottom;
        public GameObject JoystickThumb;

        public Image JoystickBottomImg;
        public Image JoystickThumbImg;
        public RectTransform RectTransform;

        public Camera UICamera;
        private EntityRef<Unit> myUnit;
        private EntityRef<MoveComponent> moveComponent;
        private EntityRef<ClientSenderComponent> clientSenderComponent;

        public int MapMask;
        public Vector2 OldPoint;
        public Vector2 NewPoint;
        public int OperateModel; // 0固定 1移动
        public float Radius; // 摇杆按钮移动的半径

        public Vector3 Direction; // 方向单位向量
        public Vector3 LastDirection;
        public Vector3 Target;

        public long JoystickTimer;

        public Unit MyUnit
        {
            get => this.myUnit;
            set => this.myUnit = value;
        }

        public MoveComponent MoveComponent
        {
            get => this.moveComponent;
            set => this.moveComponent = value;
        }

        public ClientSenderComponent ClientSenderComponent
        {
            get => this.clientSenderComponent;
            set => this.clientSenderComponent = value;
        }
    }
}