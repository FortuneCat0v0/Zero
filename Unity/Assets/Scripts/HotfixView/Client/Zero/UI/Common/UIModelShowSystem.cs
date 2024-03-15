using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(UIModelShow))]
    [EntitySystemOf(typeof(UIModelShow))]
    public static partial class UIModelShowSystem
    {
        [EntitySystem]
        private static void Awake(this UIModelShow self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.RawImg = rc.Get<GameObject>("RawImg");
            self.Root = rc.Get<GameObject>("Root");
            self.Camera = rc.Get<GameObject>("Camera");
            self.ModelRoot = rc.Get<GameObject>("ModelRoot");

            self.RawImg.GetComponent<EventTrigger>().AddEventTrigger(self.OnPointerDown, EventTriggerType.PointerDown);
            self.RawImg.GetComponent<EventTrigger>().AddEventTrigger(self.OnDrag, EventTriggerType.Drag);
            self.RawImg.GetComponent<EventTrigger>().AddEventTrigger(self.OnPointerUp, EventTriggerType.PointerUp);
        }

        private static void OnPointerDown(this UIModelShow self, PointerEventData pdata)
        {
            self.StartPosition = pdata.position;
        }

        private static void OnDrag(this UIModelShow self, PointerEventData pdata)
        {
            float eulerY = self.ModelRoot.transform.localEulerAngles.y;
            self.ModelRoot.transform.localEulerAngles =
                    pdata.position.x > self.StartPosition.x ? new Vector3(0f, eulerY - 10, 0f) : new Vector3(0f, eulerY + 10, 0f);
            self.StartPosition = pdata.position;
        }

        private static void OnPointerUp(this UIModelShow self, PointerEventData pdata)
        {
            return;
        }

        public static void SetPosition(this UIModelShow self, Vector3 rootPos, Vector3 cameraPos)
        {
            self.Root.transform.localPosition = rootPos;
            self.Camera.transform.localPosition = cameraPos;
        }

        public static async ETTask ShowModel(this UIModelShow self, string modelPath)
        {
            if (self.Model != null)
            {
                UnityEngine.Object.Destroy(self.Model);
                self.Model = null;
            }

            GameObject prefab = await self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(modelPath);
            GameObject go = UnityEngine.Object.Instantiate(prefab, self.ModelRoot.transform, true);
            self.Model = go;

            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
        }

        public static void SetShow(this UIModelShow self, bool isShow)
        {
            self.GameObject.SetActive(isShow);
        }
    }
}