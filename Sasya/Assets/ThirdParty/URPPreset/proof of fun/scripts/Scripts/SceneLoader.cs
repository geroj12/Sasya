using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   
	public void LoadSceneByIndex (int sceneBuildIndex)
	{
		SceneManager.LoadScene (sceneBuildIndex);
	}

	public void ReloadCurrentScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void OnExitButtonClicked()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
	}
	public GameObject sound;
	public GameObject soundOff;
	int value;
	public void soundOnOff ()
    {
	if (value == 0)
        {
			sound.SetActive(false);
			soundOff.SetActive(true);
			value++;
        }
        else
        {
			sound.SetActive(true);
			soundOff.SetActive(false);
			value = 0;
        }

    }
    }


