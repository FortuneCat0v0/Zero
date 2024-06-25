// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;
using UnityEngine.UI;

namespace UltimateClean
{
    /// <summary>
    /// Custom toggle component that has an associated label.
    /// </summary>
    [RequireComponent(typeof(Toggle))]
    public class ToggleWithLabel : MonoBehaviour
    {
    #pragma warning disable 649
        [SerializeField]
        private GameObject onLabel;
        [SerializeField]
        private GameObject offLabel;
    #pragma warning restore 649

        private Toggle toggle;

        private void Awake()
        {
            toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        public void OnValueChanged(bool value)
        {
            onLabel.SetActive(value);
            offLabel.SetActive(!value);
        }
    }
}