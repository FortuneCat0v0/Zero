// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateClean
{
    /// <summary>
    /// This component is used to provide idle slider animations in the demos.
    /// </summary>
    public class SliderAnimation : MonoBehaviour
    {
        public TextMeshProUGUI text;

        public float duration = 1;

        private Image image;
        private SlicedFilledImage slicedImage;

        private StringBuilder strBuilder = new StringBuilder(4);
        private int lastPercentage = -1;

        private void Awake()
        {
            image = GetComponent<Image>();
            slicedImage = GetComponent<SlicedFilledImage>();

            if (duration > 0)
                StartCoroutine(Animate());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private IEnumerator Animate()
        {
            while (true)
            {
                var ratio = 0.0f;
                var multiplier = 1.0f / duration;
                while (ratio < 1.0f)
                {
                    ratio += Time.deltaTime * multiplier;

                    if (image != null)
                        image.fillAmount = ratio;
                    else if (slicedImage != null)
                        slicedImage.fillAmount = ratio;

                    var percentage = (int)(ratio/1.0f * 100);
                    if (percentage != lastPercentage)
                    {
                        lastPercentage = percentage;
                        if (text != null)
                        {
                            strBuilder.Clear();
                            text.text = strBuilder.Append(lastPercentage).Append("%").ToString();
                        }
                    }

                    yield return null;
                }

                if (text != null)
                    text.text = "100%";

                yield return null;

                while (ratio > 0)
                {
                    ratio -= Time.deltaTime * multiplier;

                    if (image != null)
                        image.fillAmount = ratio;
                    else if (slicedImage != null)
                        slicedImage.fillAmount = ratio;

                    if (text != null)
                        text.text = $"{(int)(ratio/1.0f * 100)}%";

                    yield return null;
                }
            }
        }
    }
}