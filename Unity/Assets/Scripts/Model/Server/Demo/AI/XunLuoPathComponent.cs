using Unity.Mathematics;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class XunLuoPathComponent : Entity, IAwake
    {
        public float3[] path = { new(0, 0, 0), new(25, 0, 25), new(-25, 0, 25), new(0, 0, 50) };
        public int Index;
    }
}