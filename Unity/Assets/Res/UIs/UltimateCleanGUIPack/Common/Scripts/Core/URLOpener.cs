// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;

namespace UltimateClean
{
    /// <summary>
    /// Utility component to open a URL.
    /// </summary>
    public class URLOpener : MonoBehaviour
    {
        public string URL;

        public void OpenURL()
        {
            Application.OpenURL(URL);
        }
    }
}