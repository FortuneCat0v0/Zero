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
        public EntityRef<Unit> MyUnit;
        public EntityRef<MoveComponent> MoveComponent;
        public EntityRef<ClientSenderComponent> ClientSenderComponent;

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