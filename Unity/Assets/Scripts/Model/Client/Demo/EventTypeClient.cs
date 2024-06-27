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

    public struct OnPatchDownlodFailed
    {
        public string FileName;
        public string Error;
    }

    public struct OnPatchDownlodOver
    {
        public bool IsSucceed;
    }

    public struct ShowMessageErrorTip
    {
        public int Error;
    }

    public struct ShowItemTips
    {
        public Item Item;
        public float3 InputPoint;
        public int Occ;
    }

    /// <summary>
    /// 播动画
    /// </summary>
    public struct PlayAnimation
    {
    }

    /// <summary>
    /// 震屏
    /// </summary>
    public struct ShakeCamera
    {
    }

    public struct EffectData
    {
        public int EffectConfigId;
        public long TargetUnitId;
        public float3 Position;
        public float3 Direction;
    }

    /// <summary>
    /// 播特效
    /// </summary>
    public struct PlayEffect
    {
        public Unit Unit;
        public long EffectId;
        public EffectData EffectData;
    }

    public struct RemoveEffect
    {
        public Unit Unit;
        public long EffectId;
    }

    /// <summary>
    /// 播音效
    /// </summary>
    public struct PlaySound
    {
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