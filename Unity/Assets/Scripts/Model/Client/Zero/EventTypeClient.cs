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
}