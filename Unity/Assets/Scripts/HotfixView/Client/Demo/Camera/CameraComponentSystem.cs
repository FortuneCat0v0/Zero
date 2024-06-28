using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(CameraComponent))]
    [EntitySystemOf(typeof(CameraComponent))]
    public static partial class CameraComponentSystem
    {
        [EntitySystem]
        private static void Awake(this CameraComponent self)
        {
            self.Camera = Camera.main;
        }

        [EntitySystem]
        private static void LateUpdate(this CameraComponent self)
        {
            if (self.Unit == null)
            {
                self.Unit = UnitHelper.GetMyUnitFromCurrentScene(self.Scene());
                if (self.Unit == null)
                {
                    return;
                }
            }

            if (self.IsRotateing)
            {
                self.CalculateOffset();
            }

            self.Camera.transform.position = self.Unit.Position + self.OffsetPostion * self.LenDepth;
            self.Camera.transform.LookAt(self.Unit.Position);
        }

        /// <summary>
        /// 开始旋转，纪录当前偏移角度，用于复原
        /// </summary>
        /// <param name="self"></param>
        public static void StartRotate(this CameraComponent self)
        {
            self.IsRotateing = true;

            self.RecordAngleX = self.OffsetAngleX;
            self.RecordAngleY = self.OffsetAngleY;
        }

        /// <summary>
        /// 旋转，修改偏移角度的值，屏幕左右滑动即修改m_offsetAngleX，上下滑动修改m_offsetAngleY
        /// </summary>
        /// <param name="self"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Rotate(this CameraComponent self, float x, float y)
        {
            if (x != 0)
            {
                self.OffsetAngleX += x;
            }

            if (y != 0)
            {
                self.OffsetAngleY += y;
                self.OffsetAngleY = self.OffsetAngleY > self.MAX_ANGLE_Y ? self.MAX_ANGLE_Y : self.OffsetAngleY;
                self.OffsetAngleY = self.OffsetAngleY < self.MIN_ANGLE_Y ? self.MIN_ANGLE_Y : self.OffsetAngleY;
            }
        }

        /// <summary>
        /// 旋转结束，如需要复原镜头则，偏移角度还原并计算偏移坐标
        /// </summary>
        /// <param name="self"></param>
        /// <param name="isNeedReset"></param>
        public static void EndRotate(this CameraComponent self, bool isNeedReset = false)
        {
            self.IsRotateing = false;

            if (isNeedReset)
            {
                self.OffsetAngleY = self.RecordAngleY;
                self.OffsetAngleX = self.RecordAngleX;
                self.CalculateOffset();
            }
        }

        private static void CalculateOffset(this CameraComponent self)
        {
            self.OffsetPostion.y = self.Distance * Mathf.Sin(self.OffsetAngleY * self.ANGLE_CONVERTER);
            float newRadius = self.Distance * Mathf.Cos(self.OffsetAngleY * self.ANGLE_CONVERTER);
            self.OffsetPostion.x = newRadius * Mathf.Sin(self.OffsetAngleX * self.ANGLE_CONVERTER);
            self.OffsetPostion.z = -newRadius * Mathf.Cos(self.OffsetAngleX * self.ANGLE_CONVERTER);
        }
    }
}