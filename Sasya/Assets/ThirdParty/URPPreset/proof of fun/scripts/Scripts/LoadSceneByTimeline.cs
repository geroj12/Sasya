/// <copyright>(c) Christian Krebs 2021.</copyright>
/// <author>Christian Krebs</author>

using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LoadSceneByTimeline : MonoBehaviour
{
	#region serialized fields

	[SerializeField]
	private PlayableDirector mainDirector;

	#endregion serialized fields

	#region fields

	private string choosenScene = string.Empty;

	private int choosenIndex = -1;

	private bool loadingStarted = false;

	#endregion fields

	#region loading methods

	public void LoadSceneByName (string name)
	{
		if(!loadingStarted)
		{
			loadingStarted = true;
			choosenScene = name;
			mainDirector.Play ();
		}
	}

	public void LoadSceneByIndex (int index)
	{
		if (!loadingStarted)
		{
			loadingStarted = true;
			choosenIndex = index;
			mainDirector.Play ();
		}
	}

	public void LoadScene()
	{
		if(string.IsNullOrEmpty(choosenScene))
		{
			SceneManager.LoadScene (choosenIndex);
		}
		else
		{
			SceneManager.LoadScene (choosenScene);
		}
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
