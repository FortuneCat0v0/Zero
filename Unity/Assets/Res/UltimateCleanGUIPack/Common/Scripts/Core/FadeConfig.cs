// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;

namespace UltimateClean
{
    /// <summary>
    /// This component contains the configuration settings of a FadeButton:
    ///     - fadeTime: the fading time in seconds.
    ///     - onHoverAlpha: the target alpha value when hovering over the button.
    ///     - onClickAlpha: the target alpha value when clicking the button.
    /// </summary>
    public class FadeConfig : MonoBehaviour
    {
        public float fadeTime = 0.2f;
        public float onHoverAlpha = 0.6f;
        public float onClickAlpha = 0.7f;
    }
}