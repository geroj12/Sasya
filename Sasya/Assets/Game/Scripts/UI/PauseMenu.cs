using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Purgatory
{
    public class PauseMenu : MonoBehaviour
    {

        public GameObject audioMenuPanel;
        public GameObject resolutionMenuPanel;
        public GameObject helpMenuPanel;
        
        
        public void AudioPanel()
        {
            audioMenuPanel.gameObject.SetActive(true);
            resolutionMenuPanel.gameObject.SetActive(false);
            helpMenuPanel.gameObject.SetActive(false);
        }

        public void ResolutionPanel()
        {
            resolutionMenuPanel.gameObject.SetActive(true);
            audioMenuPanel.gameObject.SetActive(false);
            helpMenuPanel.gameObject.SetActive(false);
        }

        public void HelpPanel()
        {
            helpMenuPanel.gameObject.SetActive(true);
            resolutionMenuPanel.gameObject.SetActive(false);
            audioMenuPanel.gameObject.SetActive(false);
        } 
      
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        public void ExitGame()
        {
            SceneManager.LoadScene("UI main scene"); 
            Time.timeScale = 1;
        }

        public void ToogleFullscreen()
        {
            Screen.fullScreen = !Screen.fullScreen;
        }      
    }
}
