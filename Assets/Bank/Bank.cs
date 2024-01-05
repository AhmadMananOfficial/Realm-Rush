using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI goldText;
	[SerializeField] int startingBalance = 150;
	[HideInInspector] public int currentBalance;
	
	[SerializeField] public Image[] fullHeart;
	[HideInInspector]public int currentHeart = 1;
	[HideInInspector]public int StartingHeart = 4;
	public Sprite emptyHeart;
	
	public GameObject gameOverPanel;
	
	AudioSource audioSource; 
	public AudioClip audioClip;
   
    void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = audioClip;
		
	   currentBalance = startingBalance;
		DisplayText();
		
		currentHeart = StartingHeart;
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
			gameOverPanel.SetActive(true);
		}
	} 
	
	
	void DisplayText()
	{
		goldText.text = "Gold: " + currentBalance;
	}
	
	
}
