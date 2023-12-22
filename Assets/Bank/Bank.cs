using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI displaytext;
	
	[SerializeField] int startingBalance = 150;
	[SerializeField] int currentBalance;
	public int CurrentBalance {get {return currentBalance;} }
	
	public int currentHeart = 1;
	public int StartingHeart = 4;
	public Image[] fullHeart;
	
	public Sprite emptyHeart;
	public GameObject gameOverPanel;
	
	public GameObject enemyClone;
	AudioSource audioSource; 
	public AudioClip audioClip;
   
    void Start()
	{
		audioSource = GetComponent<AudioSource>();
		currentHeart = StartingHeart;
	   currentBalance = startingBalance;
		DisplayText();
		audioSource.clip = audioClip;
    }

    
	public void Deposit(int amount)
   {
	   currentBalance += Mathf.Abs(amount); 
	   DisplayText();
   }
    
	public void WithDraw(int amount)
	{
		currentBalance -= Mathf.Abs(amount);  
		DisplayText();

	}
	
	
	public void LoseHeart(int amount)
	{
		currentHeart -= Mathf.Abs(amount);
		
		if(currentHeart > 0)
		{
			fullHeart[currentHeart].sprite = emptyHeart;
			audioSource.Play();
		}
		else if(currentHeart == 0)
		{
			fullHeart[currentHeart].sprite = emptyHeart;
			DisableAllScripts();
			gameOverPanel.SetActive(true);
		}
	} 
	
	private void DisableAllScripts()
	{
		// Find all GameObjects with scripts in the scene
		GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

		foreach (GameObject obj in allObjects)
		{
			// Disable all scripts on the GameObject
			MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
			foreach (MonoBehaviour script in scripts)
			{
				script.enabled = false;
			}
		}
	}
	
	void DisplayText()
	{
		displaytext.text = "Gold " + currentBalance;
	}
	
	
}
