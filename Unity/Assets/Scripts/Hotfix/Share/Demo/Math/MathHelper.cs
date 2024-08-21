using System;
using Unity.Mathematics;

namespace ET
{
    public static class MathHelper
    {
        public static float ToFloat(this int self)
        {
            return self / 1000f;
        }

        /// <summary>
        /// 将向量的长度增加指定的值
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="lengthIncrease"></param>
        /// <returns></returns>
        public static float3 IncreaseLength(float3 vector, float lengthIncrease)
        {
            // 计算原始向量的长度
            float originalLength = math.length(vector);

            // 新的长度是原始长度加上增加的值
            float newLength = originalLength + lengthIncrease;

            // 计算缩放因子
            float scale = newLength / originalLength;

            // 返回新的向量
            return vector * scale;
        }

        /// <summary>
        /// 两个三维向量之间的夹角
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>度数</returns>
        public static float Angle(float3 a, float3 b)
        {
            // 计算两个向量的单位向量
            float3 aNorm = math.normalize(a);
            float3 bNorm = math.normalize(b);

            // 计算点积
            float dotProduct = math.dot(aNorm, bNorm);

            // 计算夹角 (弧度)
            float angleRad = math.acos(dotProduct);

            // 将弧度转换为度数
            float angleDeg = math.degrees(angleRad);

            return angleDeg;
        }

        /// <summary>
        /// 从四元数中提取绕Y轴的旋转角度
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns>度数</returns>
        public static float GetYAngle(quaternion rotation)
        {
            float siny_cosp = 2f * (rotation.value.w * rotation.value.y + rotation.value.x * rotation.value.z);
            float cosy_cosp = 1f - 2f * (rotation.value.y * rotation.value.y + rotation.value.z * rotation.value.z);
            float yaw = math.atan2(siny_cosp, cosy_cosp);
            return math.degrees(yaw);
        }
    }
}