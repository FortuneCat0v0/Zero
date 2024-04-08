// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UltimateClean
{
    /// <summary>
    /// The base type for the selection slider. A selection slider provides
    /// previous/next buttons that allow the player to choose from a predefined
    /// list of options. This is the base type and there are two types inheriting
    /// from it, LoopableSelectionSlider and NonLoopableSelectionSlider.
    /// </summary>
    public abstract class SelectionSlider : MonoBehaviour
    {
    #pragma warning disable 649
        [SerializeField]
        private FadeButton prevButton;
        [SerializeField]
        private FadeButton nextButton;

        [SerializeField]
        protected TextMeshProUGUI optionLabel;
        [SerializeField]
        protected TextMeshProUGUI optionNumberLabel;
    #pragma warning restore 649

        public List<string> Options = new List<string>();

        public int Index 
        { 
            get { return currentIndex; }
        }
        protected int currentIndex;

        public abstract void OnPreviousButtonPressed();
        public abstract void OnNextButtonPressed();

        protected virtual void Start()
        {
            SetCurrentOptionLabel();
        }

        protected void SetCurrentOptionLabel()
        {
            optionLabel.text = Options[currentIndex];
            optionNumberLabel.text = $"{currentIndex + 1}/{Options.Count}";
        }

        public string GetCurrentOptionText()
        {
            return Options[currentIndex];
        }

        public void SetCurrentOption(int index)
        {
            if (index >= 0 && index < Options.Count)
            {
                currentIndex = index;
                SetCurrentOptionLabel();
            }
        }
    }
}