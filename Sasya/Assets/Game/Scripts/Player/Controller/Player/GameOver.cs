using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Purgatory
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField]
        Player playerScript;

        public GameObject dieEffect;

        public GameObject gameOverScreen;
        private void Update()
        {
            if (playerScript.currentHealth <= 0)
            {           
                gameOverScreen.SetActive(true);
                FindObjectOfType<Audio>().PlayOneShot("PlayerDeath");
                StartCoroutine(DieEffect());
                
            }
        }

        private IEnumerator DieEffect()
        {
            
            //Instantiate(dieEffect, playerScript.effectSpawnTransform.position, transform.rotation);            
            yield return new WaitForSeconds(0.1f);
            
            Destroy(this.gameObject);
        }

       
    }
}
