﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int maxHitPoints = 5;
	
	[Tooltip("It added to maxHitPoints when player dies")]
	[SerializeField] int difficultyPoints = 1;
	int currentHitPoints = 0;
    
	Enemy enemy;
    
	void OnEnable()
   {
	   currentHitPoints = maxHitPoints;
   }

	void Start()
	{
		enemy = GetComponent<Enemy>();
	}
	
	void OnParticleCollision(GameObject other)
	{
		ProcessHit();
	}
	
	void ProcessHit()
	{
		currentHitPoints--;
		
		if(currentHitPoints <= 0)
		{
			enemy.RewardGold();
			maxHitPoints += difficultyPoints;
			gameObject.SetActive(false);
		}
	}
}
