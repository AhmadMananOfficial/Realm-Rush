﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
	[SerializeField] ParticleSystem projectileParticle;
	
	[SerializeField] Transform weapon;
	[SerializeField] int range = 15;
	Transform target;
    
    void Update()
	{
		FindClosestEnemy();
	    AimWeapon();
    }
    
	void FindClosestEnemy()
	{
		Enemy[] enemies = FindObjectsOfType<Enemy>();
		Transform closestTarget = null;
		float maxDistance = Mathf.Infinity;
		
		foreach(Enemy enemy in enemies)
		{
			float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
			
			if(targetDistance < maxDistance)
			{
				closestTarget = enemy.transform;
				maxDistance = targetDistance;
			}
		}
		
		target = closestTarget;
	}
    
	void AimWeapon()
	{
		float targetDistance = Vector3.Distance(transform.position, target.position);
		
		weapon.LookAt(target);
		
		if(targetDistance < range)
		{
			Attack(true);
		}
		else
		{
			Attack(false);
		}
		
		
	}
	
	void Attack(bool isActive)
	{
		var emissionModule = projectileParticle.emission;
		emissionModule.enabled = isActive;
	}
	
	
}
