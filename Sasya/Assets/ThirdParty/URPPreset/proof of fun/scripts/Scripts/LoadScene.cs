/// <copyright>(c) Christian Krebs 2021.</copyright>
/// <author>Christian Krebs</author>

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	public GameObject sound;
	public GameObject soundOff;
	int value;
	public void soundOnOff()
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
	#region loading methods

	public void LoadSceneByName (string name)
	{
		SceneManager.LoadScene (name);
	}

	public void LoadSceneByIndex (int index)
	{
		SceneManager.LoadScene (index);
	}

	public void QuitApplication ()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}

	#endregion loading methods
}
