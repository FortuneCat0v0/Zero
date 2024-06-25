// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateClean
{
    /// <summary>
    /// This component is associated to a slider's amount text and is in charge
    /// of keeping it updated with regards to the slider's current value.
    /// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SliderAmountText : MonoBehaviour
    {
    #pragma warning disable 649
        [SerializeField]
        private Slider slider;
    #pragma warning restore 649

        public string Suffix;
        public bool WholeNumber = true;

        private TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
            SetAmountText(slider.value);
        }

        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            SetAmountText(value);
        } 

        private void SetAmountText(float value)
        {
            if (WholeNumber)
                text.text = $"{(int)value}{Suffix}";
            else
                text.text = $"{Math.Round(value, 2)}{Suffix}";
        }
    }
}