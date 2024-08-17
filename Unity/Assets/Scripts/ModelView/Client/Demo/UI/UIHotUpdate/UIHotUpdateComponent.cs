using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UI))]
    public class UIHotUpdateComponent : Entity, IAwake
    {
        public GameObject PackageVersionText;
        public GameObject ProgressText { get; set; }
        public GameObject ProgressBarImg;
        public GameObject TipPanel;
        public GameObject TipText;
        public GameObject StartDownloadBtn;
    }
}