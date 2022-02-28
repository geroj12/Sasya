using UnityEngine;
using UnityEngine.UI;

namespace Purgatory
{
	public class HealthBar : MonoBehaviour
	{

		public Slider slider;
		public Gradient gradient;
		public Image fill;

		public static HealthBar singleton;

        private void Awake()
        {
			singleton = this;
        }

        public void SetMaxHealth(float health)
		{
			slider.maxValue = health;
			slider.value = health;

			fill.color = gradient.Evaluate(1f);
		}

		public void SetHealth(float health)
		{
			slider.value = health;

			fill.color = gradient.Evaluate(slider.normalizedValue);
		}         
    }
}
