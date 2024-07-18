using System.Collections;
using System.Collections.Generic;
#if MM_TEXTMESHPRO
using TMPro;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feel
{
	[AddComponentMenu("")]
	public class FeelSpringsDemoSlider : MonoBehaviour
	{
		[Header("Bindings")] 
		public Slider TargetSlider;
		#if MM_TEXTMESHPRO
		public TMP_Text ValueText;
		#endif
		public float value => TargetSlider.value;
		
		public void UpdateText()
		{
			#if MM_TEXTMESHPRO
			ValueText.text = TargetSlider.value.ToString("F2");
			#endif
		}
		
	}
}
