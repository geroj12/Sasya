using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Purgatory
{
    public class Defeated : MonoBehaviour
    {
        public GameObject winScreen;
      
        public void BossDefeated()
        {
            StartCoroutine(DefeatTimer());
        }
       
        IEnumerator DefeatTimer()
        {            
            winScreen.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(6);
            
        }
    }
}
