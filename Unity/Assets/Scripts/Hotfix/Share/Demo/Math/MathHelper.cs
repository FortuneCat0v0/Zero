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

        public static float QuaternionToEulerAngle_Y_Deg(quaternion q)
        {
            // 检查四元数是否为默认值
            if (math.lengthsq(q.value) == 0)
            {
                q = quaternion.identity;
            }
            else
            {
                q = math.normalize(q);
            }

            // 回旋角的计算
            float y = math.atan2(2f * (q.value.w * q.value.y + q.value.x * q.value.z),
                1 - 2 * (q.value.x * q.value.x + q.value.y * q.value.y));

            return math.degrees(y); // 转换为度
        }

        public static float QuaternionToEulerAngle_Y_Rad(quaternion q)
        {
            // 检查四元数是否为默认值
            if (math.lengthsq(q.value) == 0)
            {
                q = quaternion.identity;
            }
            else
            {
                q = math.normalize(q);
            }

            // 计算回旋角 (Y轴的旋转)
            float y = math.atan2(2f * (q.value.w * q.value.y + q.value.x * q.value.z),
                1 - 2 * (q.value.x * q.value.x + q.value.y * q.value.y));

            return y; // 返回弧度
        }

        /// <summary>
        /// 将四元数转换为欧拉角（以度为单位）。
        /// </summary>
        /// <param name="quat">输入的四元数</param>
        /// <returns>返回的欧拉角（以度为单位）</returns>
        public static float3 QuaternionToEuler(quaternion quat)
        {
            // 将四元数转换为旋转矩阵
            float3x3 matrix = QuaternionToMatrix(quat);

            // 从旋转矩阵提取欧拉角（以弧度为单位）
            float3 euler = MatrixToEuler(matrix);

            // 将弧度转换为度数
            return math.degrees(euler);
        }

        /// <summary>
        /// 将四元数转换为旋转矩阵。
        /// </summary>
        /// <param name="q">输入的四元数</param>
        /// <returns>返回的旋转矩阵</returns>
        private static float3x3 QuaternionToMatrix(quaternion q)
        {
            float x = q.value.x * 2.0f;
            float y = q.value.y * 2.0f;
            float z = q.value.z * 2.0f;
            float xx = q.value.x * x;
            float yy = q.value.y * y;
            float zz = q.value.z * z;
            float xy = q.value.x * y;
            float xz = q.value.x * z;
            float yz = q.value.y * z;
            float wx = q.value.w * x;
            float wy = q.value.w * y;
            float wz = q.value.w * z;

            float3x3 m = new float3x3
            {
                c0 = new float3(1.0f - (yy + zz), xy + wz, xz - wy),
                c1 = new float3(xy - wz, 1.0f - (xx + zz), yz + wx),
                c2 = new float3(xz + wy, yz - wx, 1.0f - (xx + yy))
            };

            return m;
        }

        /// <summary>
        /// 从旋转矩阵中提取欧拉角（以弧度为单位）。
        /// </summary>
        /// <param name="matrix">输入的旋转矩阵</param>
        /// <returns>返回的欧拉角（以弧度为单位）</returns>
        private static float3 MatrixToEuler(float3x3 matrix)
        {
            float3 v = float3.zero;
            if (matrix.c2.y < 0.999f)
            {
                if (matrix.c2.y > -0.999f)
                {
                    v.x = math.asin(-matrix.c2.y);
                    v.y = math.atan2(matrix.c2.x, matrix.c2.z);
                    v.z = math.atan2(matrix.c0.y, matrix.c1.y);
                }
                else
                {
                    v.x = math.PI / 2f;
                    v.y = math.atan2(matrix.c0.z, matrix.c0.x);
                    v.z = 0.0f;
                }
            }
            else
            {
                v.x = -math.PI / 2f;
                v.y = math.atan2(-matrix.c0.z, matrix.c0.x);
                v.z = 0.0f;
            }

            return v;
        }

        /// <summary>
        /// 向量在 XZ 平面的夹角（以度为单位）。
        /// </summary>
        public static float GetDirectionAngle(float3 direction)
        {
            // 计算角度（以弧度为单位）
            float angleRad = math.atan2(direction.z, direction.x);

            // 将角度转换为度数
            return math.degrees(angleRad);
        }

        /// <summary>
        /// 两点之间的目标点
        /// </summary>
        /// <param name="pointA"></param>
        /// <param name="pointB"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static float3 GetPointBetween(float3 pointA, float3 pointB, float distance)
        {
            float3 direction = math.normalize(pointB - pointA);
            return pointB - direction * distance;
        }
    }
}