using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
	[SerializeField] bool isPlaceable;
	[SerializeField] Transform defendorPrefab;
	
	
	void OnMouseDown()
	{
		if(isPlaceable)
		{
			Instantiate(defendorPrefab,transform.position,Quaternion.identity);
			isPlaceable = false;
		}
	}
}
