using System;
using System.Collections.Generic;
using System.IO;
using DotRecast.Core;
using DotRecast.Detour;
using DotRecast.Detour.Io;
using Unity.Mathematics;

namespace ET
{
    [EntitySystemOf(typeof(PathfindingComponent))]
    [FriendOf(typeof(PathfindingComponent))]
    public static partial class PathfindingComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PathfindingComponent self, string name)
        {
            self.Name = name;
            byte[] buffer = NavmeshComponent.Instance.Get(name);

            DtMeshSetReader reader = new();
            using MemoryStream ms = new(buffer);
            using BinaryReader br = new(ms);
            self.navMesh = reader.Read32Bit(br, 6); // cpp recast导出来的要用Read32Bit读取，DotRecast导出来的还没试过

            if (self.navMesh == null)
            {
                throw new Exception($"nav load fail: {name}");
            }

            self.filter = new DtQueryDefaultFilter();
            self.query = new DtNavMeshQuery(self.navMesh);
        }

        [EntitySystem]
        private static void Destroy(this PathfindingComponent self)
        {
            self.Name = string.Empty;
            self.navMesh = null;
        }

        public static void Find(this PathfindingComponent self, float3 start, float3 target, List<float3> result)
        {
            if (self.navMesh == null)
            {
                Log.Debug("寻路| Find 失败 pathfinding ptr is zero");
                throw new Exception($"pathfinding ptr is zero: {self.Scene().Name}");
            }

            RcVec3f startPos = new(-start.x, start.y, start.z);
            RcVec3f endPos = new(-target.x, target.y, target.z);

            long startRef;
            long endRef;
            RcVec3f startPt;
            RcVec3f endPt;

            self.query.FindNearestPoly(startPos, self.extents, self.filter, out startRef, out startPt, out _);
            self.query.FindNearestPoly(endPos, self.extents, self.filter, out endRef, out endPt, out _);

            self.query.FindPath(startRef, endRef, startPt, endPt, self.filter, ref self.polys, new DtFindPathOption(0, float.MaxValue));

            if (0 >= self.polys.Count)
            {
                return;
            }

            // In case of partial path, make sure the end point is clamped to the last polygon.
            RcVec3f epos = RcVec3f.Of(endPt.x, endPt.y, endPt.z);
            if (self.polys[^1] != endRef)
            {
                DtStatus dtStatus = self.query.ClosestPointOnPoly(self.polys[^1], endPt, out RcVec3f closest, out bool _);
                if (dtStatus.Succeeded())
                {
                    epos = closest;
                }
            }

            self.query.FindStraightPath(startPt, epos, self.polys, ref self.straightPath, PathfindingComponent.MAX_POLYS,
                DtNavMeshQuery.DT_STRAIGHTPATH_ALL_CROSSINGS);

            for (int i = 0; i < self.straightPath.Count; ++i)
            {
                RcVec3f pos = self.straightPath[i].pos;
                result.Add(new float3(-pos.x, pos.y, pos.z));
            }
        }

        /// <summary>
        /// 不能绕过障碍物
        /// </summary>
        /// <param name="self"></param>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <param name="result"></param>
        public static void Find2(this PathfindingComponent self, float3 start, float3 target, List<float3> result)
        {
            self.Find(start, target, result);

            if (result.Count <= 2)
            {
                return;
            }

            float epsilon = 0.2f;
            float3 startPoint = result[0];
            float3 endPoint = result[^1];

            float3 AB = endPoint - startPoint;
            float AB_squared = AB.SqrMagnitude();
            for (int i = result.Count - 2; i > 0; i--)
            {
                float3 point = result[i];

                float3 AP = point - startPoint;

                // 投影长度的平方
                float AP_dot_AB = MathHelper.Dot(AP, AB);

                // 投影点
                float3 projection = startPoint + (AP_dot_AB / AB_squared) * AB;

                // 点到直线的距离
                float distance = MathHelper.Distance(point, projection);

                if (distance <= epsilon)
                {
                    continue;
                }

                result.Clear();
                self.Find2(start, CalculateNewB(start, target, -1f), result);
                break;
            }
        }

        // 将向量的长度增加指定的值
        private static float3 IncreaseLength(float3 vector, float lengthIncrease)
        {
            // 计算原始向量的长度
            float originalLength = vector.Length();

            // 新的长度是原始长度加上增加的值
            float newLength = originalLength + lengthIncrease;

            // 计算缩放因子
            float scale = newLength / originalLength;

            // 返回新的向量
            return vector * scale;
        }

        // 计算新的点B的位置
        private static float3 CalculateNewB(float3 pointA, float3 pointB, float distanceChange)
        {
            // 计算从A到B的向量
            float3 vectorAB = pointB - pointA;

            // 增加向量的长度
            float3 newVectorAB = IncreaseLength(vectorAB, distanceChange);

            // 计算新的点B的位置
            return pointA + newVectorAB;
        }
    }
}