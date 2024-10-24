using System;
using UnityEngine;
using YIUIFramework;
using System.Collections.Generic;

namespace ET.Client
{
    public partial class LoadingPanelComponent : Entity, IUpdate
    {
        public bool IsComplete;
        public float Progress;
    }
}