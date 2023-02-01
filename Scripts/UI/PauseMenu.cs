using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Zenject;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private Button resumeButton;
	private PlayerController playerController;
	private GameManager gameManager;
	private CanvasManager canvasManager;

	public Button ResumeButton => resumeButton;

	
	[Inject]
	public void Init(PlayerController playerController, GameManager gameManager, CanvasManager canvasManager)
	{
		this.playerController = playerController;
		this.gameManager = gameManager;
		this.canvasManager = canvasManager;
	}
	
	public void ResumeGame() {

		if (playerController.PlayerHealth.Health <= 0)
		{
			RestartLevel();
		}
		else
		{
			Time.timeScale = 1;
			canvasManager.PauseMenu.gameObject.SetActive(false);
		}
	}

	public void RestartLevel() {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		playerController.PlayerHealth.Health = 3;

	}

	public void BackToMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}
	
	public void ApplicationQuit()
	{
		Application.Quit();
	}

	private void OnEnable()
	{
		Time.timeScale = 0;
	}

	private void OnDisable()
	{
		gameManager.IsInputDisabled = false;
	}
}
