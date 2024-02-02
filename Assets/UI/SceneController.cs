﻿
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

	[SerializeField] private GameObject pausedPanel;
	[SerializeField] private Animator animator;
	
	bool isPaused;
	

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void PlayGame()
	{
		LoadScene("Game"); // Game is the name of Level 01 scene name 
		FadeToLevel("Game");
	}

	public void Settings()
	{
		// Implement settings functionality here
	}

	public void PauseGame()
	{
		isPaused = true;
		Time.timeScale = 0; 
		
		pausedPanel.SetActive(true);
	}

	public void ResumeGame()
	{
		isPaused = false;
		Time.timeScale = 1;
		if(pausedPanel != null)
		{
			pausedPanel.SetActive(false);
		}
		
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void MainMenu()
	{
		LoadScene("Main Menu");
		ResumeGame(); 
		FadeToLevel("Main Menu");
	}
	
	public void QuitGame()
	{
		Application.Quit(); 
	}
	
	public void FadeToLevel (string sceneName)
	{
		animator.SetTrigger("FadeOut");
	}
	
}
	

	
	
	
	

