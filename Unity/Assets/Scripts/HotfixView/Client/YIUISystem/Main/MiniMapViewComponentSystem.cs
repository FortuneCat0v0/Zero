using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof(MiniMapViewComponent))]
    public static partial class MiniMapViewComponentSystem
    {
        [Invoke(TimerInvokeType.MiniMapTimer)]
        public class MapMiniTimer : ATimer<MiniMapViewComponent>
        {
            protected override void Run(MiniMapViewComponent self)
            {
                try
                {
                    self.UpdateMap();
                    self.UpdateMapMarker();
                }
                catch (Exception e)
                {
                    Log.Error($"move timer error: {self.Id}\n{e}");
                }
            }
        }

        [EntitySystem]
        private static void YIUIInitialize(this MiniMapViewComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MiniMapViewComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.MiniMapTimer);
        }

        [EntitySystem]
        private static async ETTask<bool> YIUIOpen(this MiniMapViewComponent self)
        {
            self.u_ComUIMapMarkerRectTransform.gameObject.SetActive(false);
            self.OnEnterScene().Coroutine();

            await ETTask.CompletedTask;
            return true;
        }

        public static async ETTask OnEnterScene(this MiniMapViewComponent self)
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

            self.ScaleRateX = self.u_ComMapRectTransform.rect.height / (camera.orthographicSize * 2);
            self.ScaleRateY = self.u_ComMapRectTransform.rect.height / (camera.orthographicSize * 2);
            self.u_ComMapRectTransform.localPosition = Vector2.zero;

            // 关闭摄像机，减少消耗。得过会，不然可能没渲染出来
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            camera.enabled = false;

            self.UpdateMap();

            self.MiniMapTimer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.MiniMapTimer, self);
        }

        public static void UpdateMap(this MiniMapViewComponent self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null || self.MapCamera == null)
            {
                return;
            }

            Vector3 unitPosition = unit.Position;
            Vector3 vector3 = new Vector3(unitPosition.x, unitPosition.z, 0f);
            Vector2 localPosition = self.GetWordToUIPositon(vector3);
            self.u_ComMapRectTransform.localPosition = new Vector2(localPosition.x * -1, localPosition.y * -1);
        }

        public static void UpdateMapMarker(this MiniMapViewComponent self)
        {
            List<Unit> allUnit = self.Root().CurrentScene().GetComponent<UnitComponent>().GetAll();
            List<long> unitIds = self.UIMapMarkers.Keys.ToList();
            foreach (Unit unit in allUnit)
            {
                if (unit.UnitType != UnitType.Player && unit.UnitType != UnitType.Monster && unit.UnitType != UnitType.NPC)
                {
                    continue;
                }

                unitIds.Remove(unit.Id);

                Vector3 unitPos = new Vector3(unit.Position.x, unit.Position.z, 0f);
                Vector3 uiPos = self.GetWordToUIPositon(unitPos);
                GameObject uiMapMarker = self.GetUIMapMarker(unit.Id);
                uiMapMarker.transform.localPosition = new Vector2(uiPos.x, uiPos.y);

                ReferenceCollector rc = uiMapMarker.GetComponent<ReferenceCollector>();
                if (unit.IsMyUnit())
                {
                    rc.Get<GameObject>("MyMarker").SetActive(true);
                }
                else if (unit.UnitType == UnitType.Player)
                {
                    rc.Get<GameObject>("NeutralMarker").SetActive(true);
                }
                else if (unit.UnitType == UnitType.Monster)
                {
                    rc.Get<GameObject>("EnemyMarker").SetActive(true);
                }
                else if (unit.UnitType == UnitType.NPC)
                {
                    rc.Get<GameObject>("AllyMarker").SetActive(true);
                }
            }

            foreach (long id in unitIds)
            {
                GameObject go = self.UIMapMarkers[id];
                go.HideChildren();
                go.SetActive(false);
                self.UIMapMarkerPool.Add(go);
                self.UIMapMarkers.Remove(id);
            }
        }

        // 连线
        // public static void SetLine(this UIMiniMapComponent self, Vector2 startPoint, Vector2 endPoint)
        // {
        //     // 角度计算
        //     Vector2 dir = endPoint - startPoint;
        //     Vector2 dirV2 = new Vector2(dir.x, dir.y);
        //     float angle = Vector2.SignedAngle(dirV2, Vector2.down);
        //
        //     var lineImage = Instantiate(lineImagePre, lineTransform.transform);
        //
        //     // 距离长度，偏转设置
        //     line.transform.Rotate(0, 0, angle);
        //     line.transform.localRotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        //     float distance = Vector2.Distance(endPoint, startPoint);
        //
        //     line.rectTransform.sizeDelta = new Vector2(4f, Mathf.Max(1, distance));
        //
        //     // 设置位置
        //     dir = endPoint + startPoint;
        //     lineImage.GetComponent<RectTransform>().position = new Vector3((float)(dir.x * 0.5f), (float)(dir.y * 0.5f), 0f);
        // }

        private static GameObject GetUIMapMarker(this MiniMapViewComponent self, long unitId)
        {
            if (self.UIMapMarkers.TryGetValue(unitId, out GameObject marker))
            {
                return marker;
            }

            GameObject go;
            if (self.UIMapMarkerPool.Count > 0)
            {
                go = self.UIMapMarkerPool[0];
                self.UIMapMarkerPool.RemoveAt(0);
            }
            else
            {
                go = UnityEngine.Object.Instantiate(self.u_ComUIMapMarkerRectTransform.gameObject, self.u_ComUIMapMarkerRectTransform.parent, true);
            }

            go.transform.localScale = Vector3.one;
            go.SetActive(true);
            self.UIMapMarkers.Add(unitId, go);
            return go;
        }

        private static Vector3 GetWordToUIPositon(this MiniMapViewComponent self, Vector3 vector3)
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

        #region YIUIEvent开始

        #endregion YIUIEvent结束
    }
}