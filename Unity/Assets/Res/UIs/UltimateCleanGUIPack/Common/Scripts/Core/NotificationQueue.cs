// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltimateClean
{
    /// <summary>
    /// This component manages a queue of notifications. It allows notifications
    /// that are launched at similar times not to overlap on the screen, but to be
    /// displayed nicely one after another. Note how this object is DontDestroyOnLoad,
    /// which means you only need to use it in your initial scene.
    /// </summary>
    public class NotificationQueue : MonoBehaviour
    {
        private Queue<QueuedNotification> pendingNotifications = new Queue<QueuedNotification>(8);

        private bool notificationActive;

        private void Start()
        {
            var existing = FindObjectOfType<NotificationQueue>();
            if (existing != null && existing != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                SceneManager.sceneLoaded += (scene, mode) =>
                {
                    pendingNotifications.Clear();
                    notificationActive = false;
                };
            }
        }

        public void EnqueueNotification(
            GameObject prefab, 
            Canvas canvas, 
            NotificationType type,
            NotificationPositionType position,
            float duration,
            string title,
            string message)
        {
            var notification = new QueuedNotification 
            {
                Prefab = prefab,
                Canvas = canvas,
                Type = type,
                Position = position,
                Duration = duration,
                Title = title,
                Message = message
            };
            pendingNotifications.Enqueue(notification);
        }

        private void Update()
        {
            if (!notificationActive)
            {
                if (pendingNotifications.Count > 0)
                {
                    var info = pendingNotifications.Dequeue();

                    var go = Instantiate(info.Prefab);
                    go.transform.SetParent(info.Canvas.transform, false);

                    var notification = go.GetComponent<Notification>();
                    notification.Launch(info.Type, info.Position, info.Duration, info.Title, info.Message);

                    notificationActive = true;
                    notification.OnCompleted += () => {
                        notificationActive = false;
                    };
                }
            }
        }
    }
}