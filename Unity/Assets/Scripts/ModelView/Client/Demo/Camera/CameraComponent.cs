using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class CameraComponent : Entity, IAwake, ILateUpdate
    {
        public Camera Camera;
        public Unit Unit { get; set; }

        // 镜头纵深
        public float LenDepth = 1;

        //相机与人物距离
        public float Distance = 11.6f;

        //初始化的偏移角度，以人物的(0,0,-1)为基准
        public float OffsetAngleX = 0;
        public float OffsetAngleY = 45;

        //相机与人物的坐标的偏移量
        public float3 OffsetPostion = new(0, 10f, -6f);

        //纪录偏移角度用于复原
        public float RecordAngleX;

        public float RecordAngleY;

        //相机是否在旋转，旋转中需要一直重新计算 m_offsetVector
        public bool IsRotateing = false;

        //弧度，用于Mathf.Sin，Mathf.Cos的计算
        public float ANGLE_CONVERTER = Mathf.PI / 180;

        //相机上下的最大最小角度
        public float MAX_ANGLE_Y = 80;
        public float MIN_ANGLE_Y = 10;
    }
}