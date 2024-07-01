﻿using System.Numerics;
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

        public static float3 Normalized(this float3 self)
        {
            float num = (float)Math.Sqrt((double)self.x * (double)self.x + (double)self.y * (double)self.y + (double)self.z * (double)self.z);
            return (double)num > 9.999999747378752E-06 ? self / num : float3.zero;
        }

        public static float SqrMagnitude(this float3 self)
        {
            return (float)((double)self.x * (double)self.x + (double)self.y * (double)self.y + (double)self.z * (double)self.z);
        }

        public static float Length(this float3 self)
        {
            return (float)Math.Sqrt((double)self.x * (double)self.x + (double)self.y * (double)self.y + (double)self.z * (double)self.z);
        }

        public static float3 IncreaseLength(float3 vector, float increase)
        {
            float originalLength = vector.Length();

            float newLength = originalLength + increase;

            float scale = newLength / originalLength;

            return new float3(vector.x * scale, vector.y * scale, vector.z * scale);
        }

        public static float Distance(float3 value1, float3 value2)
        {
            float num1 = value1.x - value2.x;
            float num2 = value1.y - value2.y;
            float num3 = value1.y - value2.y;
            return (float)Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2 + (double)num3 * (double)num3);
        }

        //
        // Summary:
        //     The well-known 3.14159265358979... value (Read Only).
        public const float PI = (float)Math.PI;

        //
        // Summary:
        //     A representation of positive infinity (Read Only).
        public const float Infinity = float.PositiveInfinity;

        //
        // Summary:
        //     A representation of negative infinity (Read Only).
        public const float NegativeInfinity = float.NegativeInfinity;

        //
        // Summary:
        //     Degrees-to-radians conversion constant (Read Only).
        public const float Deg2Rad = (float)Math.PI / 180f;

        //
        // Summary:
        //     Radians-to-degrees conversion constant (Read Only).
        public const float Rad2Deg = 57.29578f;

        public static float RadToDeg(float radians)
        {
            return (float)(radians * 180 / System.Math.PI);
        }

        public static float DegToRad(float degrees)
        {
            return (float)(degrees * System.Math.PI / 180);
        }

        public static float Angle(float3 a, float3 b)
        {
            float angle = math.acos(math.dot(a, b)) * Rad2Deg;
            return angle;
        }

        public static float Dot(float3 vector1, float3 vector2)
        {
            return (float)(vector1.x * (double)vector2.x + vector1.y * (double)vector2.y +
                vector1.z * (double)vector2.z);
        }
    }
}