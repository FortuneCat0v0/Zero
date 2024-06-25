// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;

namespace UltimateClean
{
    /// <summary>
    /// Utility component to open an info popup. See the associated InfoPopup script.
    /// </summary>
    public class InfoPopupOpener : PopupOpener
    {
        public Sprite iconSprite;
        public string iconText;

        public override void OpenPopup()
        {
            base.OpenPopup();
            m_popup.GetComponent<InfoPopup>().SetInfo(iconSprite, iconText);
        }
    }
}
