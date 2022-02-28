using System;
using UnityEngine;
using UnityEngine.UI;

namespace Purgatory
{

	public class HealthBarBoss : MonoBehaviour
	{
		public Boss boss;
		public Slider slider;
		public RectTransform[] newFillRect;
		
		public Defeated bossDead;

		public void SetMaxHealth(float health)
		{
			slider.maxValue = health;
			//transform.localScale = new Vector2(health / 100.0f , 1.3f);
		}

		
		public void SetHealth(float health)
		{
			slider.value = health;

            switch (nextPhase)
            {
				case 1:
					slider.fillRect.gameObject.SetActive(false);
					slider.fillRect = newFillRect[0];
					slider.fillRect.gameObject.SetActive(true);
					break;
				case 2:
					slider.fillRect.gameObject.SetActive(false);
					slider.fillRect = newFillRect[1];
					slider.fillRect.gameObject.SetActive(true);

					break;
				case 3:

					bossDead.BossDefeated();
					
					break;				
				default:
                    break;
            }
		}

		public GameObject[] imagesHealthbar;
		public void SelectImage(int index)
		{
			imagesHealthbar[0].SetActive(false);
			imagesHealthbar[index - 1].SetActive(false);
            
        }

		private int nextPhase = 0;
		
		public void EnterPhase(int currentPhaseIdx, float maxHealth)
		{
			FindObjectOfType<Audio>().PlayOneShot("BossTransformation");
			slider.maxValue = maxHealth;  		
			SelectImage(currentPhaseIdx);
			nextPhase += 1; 
		}
	}
}
