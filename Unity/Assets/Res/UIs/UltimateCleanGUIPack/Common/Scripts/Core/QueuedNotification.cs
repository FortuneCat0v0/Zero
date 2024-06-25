// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;

namespace UltimateClean
{
    /// <summary>
    /// This type is used to store the information of a queued notification.
    /// </summary>
    public class QueuedNotification
    {
        public GameObject Prefab;
        public Canvas Canvas;
        public NotificationType Type;
        public NotificationPositionType Position;
        public float Duration;
        public string Title;
        public string Message;
    }
}