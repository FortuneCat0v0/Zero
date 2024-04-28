using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [ComponentOf(typeof (UI))]
    public class UIHotUpdateComponent: Entity, IAwake
    {
        public GameObject PackageVersionText;
        public Image ProgressBarImg;
        public TMP_Text ProgressText;
    }
}