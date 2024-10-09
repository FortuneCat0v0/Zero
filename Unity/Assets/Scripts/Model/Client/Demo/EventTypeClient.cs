using Unity.Mathematics;

namespace ET.Client
{
    public struct StartHotUpDate
    {
        public string PackageVersion;
    }

    public struct OnPatchDownloadProgress
    {
        public int CurrentDownloadCount;
        public int TotalDownloadCount;
        public long CurrentDownloadSizeBytes;
        public long TotalDownloadSizeBytes;
    }

    public struct OnPatchDownloadFailed
    {
        public string FileName;
        public string Error;
    }

    public struct OnPatchDownloadOver
    {
        public bool IsSucceed;
    }

    public struct ShowErrorTip
    {
        public int Error;
    }

    public struct ShowItemTips
    {
        public Item Item;
        public float3 InputPoint;
        public int Occ;
    }

    public struct PlayAnimation
    {
    }

    public struct ShakeCamera
    {
    }

    public struct EffectData
    {
        public int EffectConfigId;
        public float3 Position;
        public float Angle;
    }

    public struct PlayEffect
    {
        public Unit Unit;
        public long EffectId; // 可能要通过Id拿到表现层的特效，状态做一些调整，先留着吧
        public EffectData EffectData;
    }

    public struct RemoveEffect
    {
        public Unit Unit;
        public long EffectId;
    }

    public struct PlaySound
    {
        public int AudioConfigId;
    }

    /// <summary>
    /// 播放材质（金身/石化）
    /// </summary>
    public struct PlayMaterial
    {
    }

    /// <summary>
    /// 恢复材质
    /// </summary>
    public struct RecoverMaterial
    {
    }
}