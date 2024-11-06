using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ET.Client
{
    public class ConvexPolygonChecker : EditorWindow
    {
        [MenuItem("GameObject/检查凸多边形", false, 0)]
        private static void CheckConvexPolygon()
        {
            GameObject selectedObject = Selection.activeGameObject;
            if (selectedObject == null)
            {
                Debug.LogWarning("请先选择一个物体。");
                return;
            }

            // 获取子物体的本地坐标
            List<Vector2> localPositions = new List<Vector2>();
            foreach (Transform child in selectedObject.transform)
            {
                localPositions.Add(new Vector2(child.localPosition.x, child.localPosition.z));
            }

            // 检查点的数量是否在 3 到 8 之间
            if (localPositions.Count < 3 || localPositions.Count > 8)
            {
                Debug.LogWarning("子物体数量需在 3 到 8 之间，当前数量：" + localPositions.Count);
                return;
            }

            // 判断能否围成一个顺时针凸多边形
            if (IsConvexPolygon(localPositions))
            {
                string coordinates = string.Join(";", localPositions.ConvertAll(p => $"{p.x},{p.y}"));
                Debug.Log("该物体的子物体可以形成顺时针凸多边形，坐标点如下：");
                Debug.Log(coordinates);
            }
            else
            {
                Debug.LogWarning("该物体的子物体无法形成顺时针凸多边形。");
            }
        }

        // 判断是否为凸多边形
        private static bool IsConvexPolygon(List<Vector2> points)
        {
            bool isClockwise = false;
            bool isConvex = true;

            for (int i = 0; i < points.Count; i++)
            {
                Vector2 p1 = points[i];
                Vector2 p2 = points[(i + 1) % points.Count];
                Vector2 p3 = points[(i + 2) % points.Count];

                float crossProduct = CrossProduct(p1, p2, p3);
                if (i == 0)
                {
                    isClockwise = crossProduct < 0;
                }
                else if (isClockwise != (crossProduct < 0))
                {
                    isConvex = false;
                    break;
                }
            }

            return isConvex;
        }

        // 计算叉积用于判断顺时针方向
        private static float CrossProduct(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            return (p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x);
        }
    }
}