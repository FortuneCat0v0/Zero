// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateClean
{
    /// <summary>
    /// This component is used to provide idle progress bar animations in the demos.
    /// </summary>
    public class ProgressBarAnimation : MonoBehaviour
    {
        public Image progressBar;
        public TextMeshProUGUI text;

        public float duration = 1;

        private void Awake()
        {
            if (duration > 0)
            {
                StartCoroutine(Animate());
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator Animate()
        {
            while (true)
            {
                var time = 0.0f;
                while (progressBar.fillAmount < 1.0f)
                {
                    time += Time.deltaTime;
                    progressBar.fillAmount = Mathf.Lerp(0.0f, 1.0f, time/duration);
                    yield return null;
                }

                time = 0.0f;
                while (progressBar.fillAmount > 0.0f)
                {
                    time += Time.deltaTime;
                    progressBar.fillAmount = Mathf.InverseLerp(1.0f, 0.0f, time/duration);
                    yield return null;
                }
            }
        }
    }
}