using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI displaytext;
	
	[SerializeField] int startingBalance = 150;
	[SerializeField] int currentBalance;
	public int CurrentBalance {get {return currentBalance;} }
	
   
    void Start()
    {
	    currentBalance = startingBalance;
	    DisplayText();
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
		
		if(CurrentBalance < 0)
		{
			ReloadScene();
		}
	}
	
	void DisplayText()
	{
		displaytext.text = "Gold " + currentBalance;
	}
	
	void ReloadScene()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentScene);
	}
}
