using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.UI;

namespace ET.Client
{
    public partial class JoystickViewComponent : Entity, IUpdate
    {
        public Camera UICamera;
        public Camera MainCamera;
        private EntityRef<Unit> unit;
        public Unit MyUnit { get => this.unit; set => this.unit = value; }

        private EntityRef<MoveComponent> moveComponent;
        public MoveComponent MoveComponent { get => this.moveComponent; set => this.moveComponent = value; }
        private EntityRef<ClientSenderComponent> clientSenderComponent;
        public ClientSenderComponent ClientSenderComponent { get => this.clientSenderComponent; set => this.clientSenderComponent = value; }

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