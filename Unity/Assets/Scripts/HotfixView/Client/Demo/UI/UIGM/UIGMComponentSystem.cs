using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UIGMComponent))]
    [EntitySystemOf(typeof(UIGMComponent))]
    public static partial class UIGMComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIGMComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.Go_Panel = rc.Get<GameObject>("Go_Panel");
            self.Img_Top = rc.Get<GameObject>("Img_Top");
            self.Btn_Close = rc.Get<GameObject>("Btn_Close");

            self.Img_Top.GetComponent<EventTrigger>().AddEventTrigger(self.OnBeginDrag, EventTriggerType.BeginDrag);
            self.Img_Top.GetComponent<EventTrigger>().AddEventTrigger(self.OnDrag, EventTriggerType.Drag);
            self.Img_Top.GetComponent<EventTrigger>().AddEventTrigger(self.OnEndDrag, EventTriggerType.EndDrag);

            self.Btn_Close.GetComponent<Button>().AddListener(() => { UIHelper.Remove(self.Scene(), UIType.UIGM); });
        }

        private static void OnBeginDrag(this UIGMComponent self, PointerEventData eventData)
        {
            self.OriginalPanelPosition = self.Go_Panel.GetComponent<RectTransform>().anchoredPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(self.GetParent<UI>().GameObject.GetComponent<RectTransform>(),
                eventData.position,
                eventData.pressEventCamera,
                out self.OriginalPointPosition);
        }

        private static void OnDrag(this UIGMComponent self, PointerEventData eventData)
        {
            if (self.IsMouseWithinScreen(eventData))
            {
                Vector2 localPoint;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(self.GetParent<UI>().GameObject.GetComponent<RectTransform>(),
                        eventData.position,
                        eventData.pressEventCamera,
                        out localPoint))
                {
                    Vector3 offsetToOriginal = localPoint - self.OriginalPointPosition;
                    self.Go_Panel.GetComponent<RectTransform>().localPosition = new Vector3(self.OriginalPanelPosition.x + offsetToOriginal.x,
                        self.OriginalPanelPosition.y + offsetToOriginal.y, 0);
                }
            }
        }

        private static void OnEndDrag(this UIGMComponent self, PointerEventData eventData)
        {
            // Optional: Add logic here if you want to snap the panel to a specific position after dragging
        }

        // private static void OnGMSendBtn(this UIMainComponent self)
        // {
        //     string message = self.GMInput.GetComponent<TMP_InputField>().text;
        //     if (string.IsNullOrEmpty(message))
        //     {
        //         return;
        //     }
        //
        //     C2M_GM c2MGm = C2M_GM.Create();
        //     c2MGm.GMMessage = message;
        //     self.Root().GetComponent<ClientSenderComponent>().Call(c2MGm).Coroutine();
        //     self.GMInput.GetComponent<TMP_InputField>().text = "";
        // }

        private static bool IsMouseWithinScreen(this UIGMComponent self, PointerEventData eventData)
        {
            Vector2 mousePosition = eventData.position;

            return mousePosition.x >= 0 && mousePosition.x <= Screen.width &&
                    mousePosition.y >= 0 && mousePosition.y <= Screen.height;
        }
    }
}