using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(UIMiniMapComponent))]
    [EntitySystemOf(typeof(UIMiniMapComponent))]
    public static partial class UIMiniMapComponentSystem
    {
        [Invoke(TimerInvokeType.MiniMapTimer)]
        public class MapMiniTimer : ATimer<UIMiniMapComponent>
        {
            protected override void Run(UIMiniMapComponent self)
            {
                try
                {
                    self.UpdateMap();
                    self.UpdateInfo();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void Awake(this UIMiniMapComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.RawImage = rc.Get<GameObject>("RawImage");

            self.OnEnterScene();
        }

        [EntitySystem]
        private static void Destroy(this UIMiniMapComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.MiniMapTimer);
        }

        public static void OnEnterScene(this UIMiniMapComponent self)
        {
            GameObject mapCamera = GameObject.Find("Global/MapCamera");
            if (mapCamera == null)
            {
                string path = AssetPathHelper.GetUnitPath("Component/MapCamera");
                GameObject prefab = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                mapCamera = UnityEngine.Object.Instantiate(prefab, GameObject.Find("Global").transform);
                self.MapCamera = mapCamera;
                mapCamera.name = "MapCamera";
            }

            mapCamera.transform.position = new Vector3(0, 20f, 0);
            mapCamera.transform.eulerAngles = new Vector3(90, 0, 0);

            Camera camera = mapCamera.GetComponent<Camera>();
            camera.enabled = true;

            self.ScaleRateX = self.RawImage.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);
            self.ScaleRateY = self.RawImage.GetComponent<RectTransform>().rect.height / (camera.orthographicSize * 2);
            self.RawImage.transform.localPosition = Vector2.zero;

            // 关闭摄像机，减少消耗。得过会，不然可能没渲染出来
            // await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            // camera.enabled = false;

            self.UpdateMap();

            self.MiniMapTimer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(200, TimerInvokeType.MiniMapTimer, self);
        }

        public static void UpdateMap(this UIMiniMapComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null || self.MapCamera == null)
            {
                return;
            }

            Vector3 unitPosition = unit.Position;
            Vector3 vector3 = new Vector3(unitPosition.x, unitPosition.z, 0f);
            Vector2 localPosition = self.GetWordToUIPositon(vector3);
            self.RawImage.transform.localPosition = new Vector2(localPosition.x * -1, localPosition.y * -1);
            // self.EG_HeadListRectTransform.localPosition = new Vector2(localPosition.x * -1, localPosition.y * -1);
        }

        public static void UpdateInfo(this UIMiniMapComponent self)
        {
            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());

            if (myUnit == null)
            {
                return;
            }
        }

        private static Vector3 GetWordToUIPositon(this UIMiniMapComponent self, Vector3 vector3)
        {
            GameObject mapCamera = self.MapCamera;
            vector3.x -= mapCamera.transform.position.x;
            vector3.y -= mapCamera.transform.position.z;

            Quaternion rotation = Quaternion.Euler(0, 0, 1 * mapCamera.transform.eulerAngles.y);
            vector3 = rotation * vector3;

            vector3.x *= self.ScaleRateX;
            vector3.y *= self.ScaleRateY;
            return vector3;
        }
    }
}