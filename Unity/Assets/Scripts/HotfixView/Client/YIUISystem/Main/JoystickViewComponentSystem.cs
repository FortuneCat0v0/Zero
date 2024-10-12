using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(JoystickViewComponent))]
    public static partial class JoystickViewComponentSystem
    {
        [EntitySystem]
        private static void YIUIInitialize(this JoystickViewComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this JoystickViewComponent self)
        {
        }

        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this JoystickViewComponent self)
        {
            self.UICamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            self.MainCamera = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>();
            self.MyUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            Unit myUnit = self.MyUnit;
            self.MoveComponent = myUnit.GetComponent<MoveComponent>();
            self.ClientSenderComponent = self.Root().GetComponent<ClientSenderComponent>();

            self.MapMask = LayerMask.GetMask("Map");
            self.JoystickModel = EJoystickModel.Fixed;
            self.Radius = 110f;
            self.ResetUI();

            await ETTask.CompletedTask;
            return true;
        }

        [EntitySystem]
        private static void Update(this JoystickViewComponent self)
        {
            self.SendMove();
        }

        #region YIUIEvent开始

        private static void OnEventOnBeginDragAction(this JoystickViewComponent self, object p1)
        {
            PointerEventData pdata = p1 as PointerEventData;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(self.u_ComStartAreaRectTransform, pdata.position, self.UICamera,
                out self.OldPoint);
            self.SetAlpha(1f);
            if (self.JoystickModel == EJoystickModel.Fixed)
            {
                self.u_ComJoystickRectTransform.gameObject.SetActive(true);
                self.u_ComJoystickBottomRectTransform.localPosition = Vector3.zero;
                self.u_ComJoystickThumbRectTransform.localPosition = Vector3.zero;
                self.OldPoint = Vector2.zero;
            }
            else
            {
                self.u_ComJoystickRectTransform.gameObject.SetActive(true);
                self.u_ComJoystickBottomRectTransform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
                self.u_ComJoystickThumbRectTransform.localPosition = new Vector3(self.OldPoint.x, self.OldPoint.y, 0f);
            }

            // 判断当前状态是否可以使用摇杆
            // 。。。

            self.IsDrag = true;
            self.LastDirection = Vector3.zero;
        }

        private static void OnEventOnDragAction(this JoystickViewComponent self, object p1)
        {
            PointerEventData pdata = p1 as PointerEventData;
            self.SetDirection(pdata);
        }

        private static void OnEventOnEndDragAction(this JoystickViewComponent self, object p1)
        {
            self.IsDrag = false;
            self.LastDirection = Vector3.zero;
            C2M_Stop c2MStop = C2M_Stop.Create();
            ClientSenderComponent clientSenderComponent = self.ClientSenderComponent;
            clientSenderComponent.Send(c2MStop);
            self.ResetUI();
        }

        #endregion YIUIEvent结束

        private static void SetAlpha(this JoystickViewComponent self, float value)
        {
            Color newColor = new(1f, 1f, 1f);
            newColor.a = value;
            self.u_ComJoystickBottomImage.color = newColor;
            self.u_ComJoystickThumbImage.color = newColor;

            self.u_ComPositionFocusRectTransform.gameObject.SetActive(false);
        }

        /// <summary>
        /// 移动摇杆按钮，并得到方向
        /// </summary>
        /// <param name="self"></param>
        /// <param name="pdata"></param>
        /// <returns></returns>
        private static void SetDirection(this JoystickViewComponent self, PointerEventData pdata)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(self.u_ComStartAreaRectTransform, pdata.position, self.UICamera,
                out self.NewPoint);
            float maxDistance = Vector2.Distance(self.OldPoint, self.NewPoint);
            if (maxDistance < self.Radius)
            {
                self.u_ComJoystickThumbRectTransform.localPosition = self.NewPoint;
            }
            else
            {
                self.NewPoint = self.OldPoint + (self.NewPoint - self.OldPoint).normalized * self.Radius;
                self.u_ComJoystickThumbRectTransform.localPosition = self.NewPoint;
            }

            self.Direction = (self.NewPoint - self.OldPoint).normalized;

            float angle = Mathf.Atan2(self.Direction.y, self.Direction.x) * Mathf.Rad2Deg;
            self.u_ComPositionFocusRectTransform.localRotation = Quaternion.Euler(0, 0, angle - 135);
            self.u_ComPositionFocusRectTransform.gameObject.SetActive(true);

            self.Direction.z = self.Direction.y;
            self.Direction.y = 0;
        }

        private static void SendMove(this JoystickViewComponent self)
        {
            if (!self.IsDrag)
            {
                return;
            }

            Unit myUnit = self.MyUnit;
            if (myUnit == null)
            {
                return;
            }

            // 切换方向立刻从新寻路，保持同一方向则要马上完成之前的移动后。解决卡边会发送寻路消息频繁
            MoveComponent moveComponent = self.MoveComponent;
            if (self.LastDirection != Vector3.zero && Vector3.Angle(self.Direction, self.LastDirection) < 10f &&
                (moveComponent.Targets.Count > 1 || Vector3.Distance(self.LastUnitPosition, myUnit.Position) < 0.001f))
            {
                return;
            }

            // 适应摄像机
            Quaternion rotation = Quaternion.Euler(0, self.MainCamera.transform.eulerAngles.y, 0);
            Vector3 direction = rotation * self.Direction;

            Vector3 start = myUnit.Position;
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

            if (Vector3.Distance(target, myUnit.Position) < 0.1f)
            {
                return;
            }

            self.LastDirection = self.Direction;
            self.LastUnitPosition = myUnit.Position;

            C2M_PathfindingResult c2MPathfindingResult = C2M_PathfindingResult.Create();
            c2MPathfindingResult.Position = target;
            ClientSenderComponent clientSenderComponent = self.ClientSenderComponent;
            clientSenderComponent.Send(c2MPathfindingResult);
        }

        private static void ResetUI(this JoystickViewComponent self)
        {
            self.SetAlpha(0.3f);
            if (self.JoystickModel == EJoystickModel.Fixed)
            {
                self.u_ComJoystickBottomRectTransform.localPosition = Vector3.zero;
                self.u_ComJoystickThumbRectTransform.localPosition = Vector3.zero;
            }
            else
            {
                self.u_ComJoystickRectTransform.gameObject.SetActive(false);
            }
        }
    }
}