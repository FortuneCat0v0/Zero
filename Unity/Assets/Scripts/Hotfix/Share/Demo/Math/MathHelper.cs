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
        /// 从四元数提取欧拉角（以度为单位）。
        /// </summary>
        /// <param name="q">需要转换的四元数</param>
        /// <returns>返回的欧拉角（以度为单位）</returns>
        public static float3 ToEulerAngles(this quaternion q)
        {
            return math.degrees(ToEulerRad(q));
        }

        /// <summary>
        /// 从四元数提取欧拉角（以弧度为单位）。
        /// </summary>
        /// <param name="q">需要转换的四元数</param>
        /// <returns>返回的欧拉角（以弧度为单位）</returns>
        private static float3 ToEulerRad(quaternion q)
        {
            // 计算旋转矩阵的各个元素
            float sinr_cosp = 2 * (q.value.w * q.value.x + q.value.y * q.value.z);
            float cosr_cosp = 1 - 2 * (q.value.x * q.value.x + q.value.y * q.value.y);
            float roll = math.atan2(sinr_cosp, cosr_cosp);

            float sinp = 2 * (q.value.w * q.value.y - q.value.z * q.value.x);
            float pitch;
            if (math.abs(sinp) >= 1)
                pitch = math.PI / 2 * math.sign(sinp); // 使用90度，如果超出范围
            else
                pitch = math.asin(sinp);

            float siny_cosp = 2 * (q.value.w * q.value.z + q.value.x * q.value.y);
            float cosy_cosp = 1 - 2 * (q.value.y * q.value.y + q.value.z * q.value.z);
            float yaw = math.atan2(siny_cosp, cosy_cosp);

            return new float3(roll, pitch, yaw);
        }

        /// <summary>
        /// 计算点 A 和点 B 在 XZ 平面的夹角（以度为单位）。
        /// </summary>
        /// <param name="pointA">点 A 的坐标</param>
        /// <param name="pointB">点 B 的坐标</param>
        /// <returns>返回点 A 和点 B 在 XZ 平面的夹角（以度为单位）</returns>
        public static float GetAngleBetweenPointsXZ(float3 pointA, float3 pointB)
        {
            // 计算从 A 到 B 的向量
            float3 direction = pointB - pointA;

            // 计算角度（以弧度为单位）
            float angleRad = math.atan2(direction.z, direction.x);

            // 将角度转换为度数
            return math.degrees(angleRad);
        }
    }
}