using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int rewardGold = 25;
	[SerializeField] int penaltyGold = 30;
	[SerializeField] int losingHeart = 1;
	
	
	Bank bank;
	
	
    void Start()
	{
		
	    bank = FindObjectOfType<Bank>();  
    }

    
	public void RewardGold()
	{
		if(bank == null) return;
		
		bank.Deposit(rewardGold);  
	}
   
	public void PenaltyGold()
	{
		if(bank == null) return;
		
		bank.WithDraw(penaltyGold); 
	}
   
	public void LosingHeart()
	{
		if(bank == null) return;
		
		bank.LoseHeart(losingHeart);
	}
	
	
}
