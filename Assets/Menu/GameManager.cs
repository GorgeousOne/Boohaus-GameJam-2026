using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	private List<string> loadedScenes = new List<string>();

	public bool IsGameRunning {get; private set;}


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

	public void StartGame()
	{
		IsGameRunning = true;
        LoadScene("Dressing Room");
		UiManager.Instance.HideStartScreen();
	}


	//load all levels additively ontop of Game scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		loadedScenes.Add(sceneName);
    }

    public void ChangeLevel(string sceneName)
    {
        foreach (AudioSource audio in FindObjectsByType<AudioSource>(FindObjectsSortMode.None)) {
            audio.Stop();
        }
        foreach (var scene in loadedScenes)
        {
            Debug.Log("UNLOAD " + scene);
            SceneManager.UnloadSceneAsync(scene);
        }
        loadedScenes.Clear();
        LoadScene(sceneName);
    }

	public void ExitLevel()
	{
		foreach (var scene in loadedScenes)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
        loadedScenes.Clear();
		UiManager.Instance.ShowMainMenu();
	}

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
		loadedScenes.Remove(sceneName);
    }

	public void Quit()
	{
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#else
        Application.Quit();
#endif
	}
}