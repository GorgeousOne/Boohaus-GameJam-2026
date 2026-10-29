using UnityEngine;

// yeah maybe move pause logic somewhere else
public class UiManager : MonoBehaviour
{

	public static UiManager Instance;

	public GameObject startScreen;
	public GameObject pauseScreen;

	private bool isGamePaused;

	void Awake ()
	{
		Instance ??= this;
		startScreen.gameObject.SetActive(true);
		pauseScreen.gameObject.SetActive(false);
		isGamePaused = false;
    }

	public void HideStartScreen()
	{
		startScreen.gameObject.SetActive(false);
        InputManager.PlayerInput.SwitchCurrentActionMap("Player");
    }

	public void ShowMainMenu()
	{
		pauseScreen.gameObject.SetActive(false);
		startScreen.gameObject.SetActive(true);
	}

	void Update()
	{
		if (GameManager.Instance.IsGameRunning && !isGamePaused && InputManager.I.MenuOpenInput)
		{
			PauseGame();
		}
		if (GameManager.Instance.IsGameRunning && isGamePaused && InputManager.I.MenuCloseInput)
		{
			ResumeGame();
		}
	}

	// show pause ui & disable player inputs
	public void PauseGame()
	{
		isGamePaused = true;
		Time.timeScale = 0;
		pauseScreen.gameObject.SetActive(true);
		InputManager.PlayerInput.SwitchCurrentActionMap("UI");
	}

	public void ResumeGame()
	{
		isGamePaused = false;
		Time.timeScale = 1;
		pauseScreen.gameObject.SetActive(false);
		InputManager.PlayerInput.SwitchCurrentActionMap("Player");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}