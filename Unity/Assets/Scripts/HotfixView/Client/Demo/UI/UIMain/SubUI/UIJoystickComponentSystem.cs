using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(MoveComponent))]
    [FriendOf(typeof(OperaComponent))]
    [FriendOf(typeof(UIJoystickComponent))]
    [EntitySystemOf(typeof(UIJoystickComponent))]
    public static partial class UIJoystickComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIJoystickComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.StartArea = rc.Get<GameObject>("StartArea");
            self.Joystick = rc.Get<GameObject>("Joystick");
            self.JoystickBottom = rc.Get<GameObject>("JoystickBottom");
            self.PositionFocus0 = rc.Get<GameObject>("PositionFocus0");
            self.PositionFocus1 = rc.Get<GameObject>("PositionFocus1");
            self.PositionFocus2 = rc.Get<GameObject>("PositionFocus2");
            self.PositionFocus3 = rc.Get<GameObject>("PositionFocus3");
            self.JoystickThumb = rc.Get<GameObject>("JoystickThumb");

            self.JoystickBottomImg = self.JoystickBottom.GetComponent<Image>();
            self.JoystickThumbImg = self.JoystickThumb.GetComponent<Image>();
            self.RectTransform = self.StartArea.GetComponent<RectTransform>();
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            self.MyUnit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
            self.MoveComponent = self.MyUnit.GetComponent<MoveComponent>();
            self.ClientSenderComponent = self.Root().GetComponent<ClientSenderComponent>();

            // 事件触发顺序 如果拖拽 PointerDown、BeginDrag、Drag、PointerUp、EndDrag 未拖拽 PointerDown、PointerUp
            self.StartArea.GetComponent<EventTrigger>().AddEventTrigger(self.OnPointerDown, EventTriggerType.PointerDown);
            self.StartArea.GetComponent<EventTrigger>().AddEventTrigger(self.OnBeginDrag, EventTriggerType.BeginDrag);
            self.StartArea.GetComponent<EventTrigger>().AddEventTrigger(self.OnDrag, EventTriggerType.Drag);
            self.StartArea.GetComponent<EventTrigger>().AddEventTrigger(self.OnPointerUp, EventTriggerType.PointerUp);
            self.StartArea.GetComponent<EventTrigger>().AddEventTrigger(self.OnEndDrag, EventTriggerType.EndDrag);

            self.MapMask = LayerMask.GetMask("Map");
            self.OperateModel = 1;
            self.Radius = 110f;
            self.Joystick.SetActive(false);
        }

        [EntitySystem]
        private static void FixedUpdate(this UIJoystickComponent self)
        {
            self.SendMove();
        }

        private static void OnPointerDown(this UIJoystickComponent self, PointerEventData pdata)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(self.RectTransform, pdata.position, self.UICamera, out self.OldPoint);
            self.SetAlpha(1f);
            if (self.OperateModel == 0)
            {
                self.Joystick.SetActive(true);
                self.JoystickBottom.transform.localPosition = Vector3.zero;
                self.JoystickThumb.transform.localPosition = Vector3.zero;
                self.OldPoint = Vector2.zero;
            }
            else
            {
                self.Joystick.SetActive(true);
                self.JoystickBottom.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
                self.JoystickThumb.transform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
            }
        }

        private static void OnBeginDrag(this UIJoystickComponent self, PointerEventData pdata)
        {
            // 判断当前状态是否可以使用摇杆
            // 。。。

            self.IsDrag = true;
            self.LastDirection = Vector3.zero;
        }

        private static void OnDrag(this UIJoystickComponent self, PointerEventData pdata)
        {
            self.SetDirection(pdata);
        }

        private static void OnPointerUp(this UIJoystickComponent self, PointerEventData pdata)
        {
            self.ResetUI();
        }

        private static void OnEndDrag(this UIJoystickComponent self, PointerEventData pdata)
        {
            self.IsDrag = false;
            self.LastDirection = Vector3.zero;
            self.ClientSenderComponent.Send(C2M_Stop.Create());
            self.ResetUI();
        }

        private static void SetAlpha(this UIJoystickComponent self, float value)
        {
            Color newColor = new(1f, 1f, 1f);
            newColor.a = value;
            self.JoystickBottomImg.color = newColor;
            self.JoystickThumbImg.color = newColor;

            self.PositionFocus0.SetActive(false);
            self.PositionFocus1.SetActive(false);
            self.PositionFocus2.SetActive(false);
            self.PositionFocus3.SetActive(false);
        }

        /// <summary>
        /// 移动摇杆按钮，并得到方向
        /// </summary>
        /// <param name="self"></param>
        /// <param name="pdata"></param>
        /// <returns></returns>
        private static void SetDirection(this UIJoystickComponent self, PointerEventData pdata)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(self.RectTransform, pdata.position, self.UICamera, out self.NewPoint);
            float maxDistance = Vector2.Distance(self.OldPoint, self.NewPoint);
            if (maxDistance < self.Radius)
            {
                self.JoystickThumb.transform.localPosition = self.NewPoint;
            }
            else
            {
                self.NewPoint = self.OldPoint + (self.NewPoint - self.OldPoint).normalized * self.Radius;
                self.JoystickThumb.transform.localPosition = self.NewPoint;
            }

            self.Direction = (self.NewPoint - self.OldPoint).normalized;

            self.PositionFocus0.SetActive(self.Direction.x < 0 && self.Direction.y > 0);
            self.PositionFocus1.SetActive(self.Direction.x > 0 && self.Direction.y > 0);
            self.PositionFocus2.SetActive(self.Direction.x > 0 && self.Direction.y < 0);
            self.PositionFocus3.SetActive(self.Direction.x < 0 && self.Direction.y < 0);

            self.Direction.z = self.Direction.y;
            self.Direction.y = 0;
        }

        private static void SendMove(this UIJoystickComponent self)
        {
            if (!self.IsDrag)
            {
                return;
            }

            if (self.MyUnit == null)
            {
                return;
            }

            // 切换方向立刻从新寻路，保持同一方向则要马上完成之前的移动后。解决卡边会发送寻路消息频繁
            if (self.LastDirection != Vector3.zero && Vector3.Angle(self.Direction, self.LastDirection) < 10f &&
                (self.MoveComponent.Targets.Count > 1 || Vector3.Distance(self.LastUnitPosition, self.MyUnit.Position) < 0.001f))
            {
                return;
            }

            Quaternion rotation = Quaternion.Euler(0, self.MainCamera.transform.eulerAngles.y, 0);
            Vector3 direction = rotation * self.Direction;

            Vector3 start = self.MyUnit.Position;
            float intveral = 0.25f;
            int maxStep = 40;
            Vector3 target = Vector3.zero;
            for (int i = 1; i <= maxStep; i++)
            {
                RaycastHit hit;
                Physics.Raycast(start + direction * (i * intveral) + new Vector3(0f, 10f, 0f), Vector3.down, out hit, 100, self.MapMask);

                if (hit.collider == null)
                {
                    break;
                }

                target = hit.point;
            }

            if (target == Vector3.zero)
            {
                return;
            }

            self.LastDirection = self.Direction;
            self.LastUnitPosition = self.MyUnit.Position;

            C2M_PathfindingResult c2MPathfindingResult = C2M_PathfindingResult.Create();
            c2MPathfindingResult.Position = target;
            self.ClientSenderComponent.Send(c2MPathfindingResult);
        }

        private static void ResetUI(this UIJoystickComponent self)
        {
            self.SetAlpha(0.3f);
            if (self.OperateModel == 0)
            {
                self.JoystickBottom.transform.localPosition = Vector3.zero;
                self.JoystickThumb.transform.localPosition = Vector3.zero;
            }
            else
            {
                self.Joystick.SetActive(false);
            }
        }
    }
}