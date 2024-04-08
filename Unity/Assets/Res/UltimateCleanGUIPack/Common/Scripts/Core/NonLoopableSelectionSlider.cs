// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

namespace UltimateClean
{
    /// <summary>
    /// A non-loopable selection slider.
    /// </summary>
    public class NonLoopableSelectionSlider : SelectionSlider
    {
        public override void OnPreviousButtonPressed()
        {
            --currentIndex;
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }

            SetCurrentOptionLabel();
        }

        public override void OnNextButtonPressed()
        {
            ++currentIndex;
            if (currentIndex > Options.Count - 1)
            {
                currentIndex = Options.Count - 1;
            }

            SetCurrentOptionLabel();
        }
    }
}