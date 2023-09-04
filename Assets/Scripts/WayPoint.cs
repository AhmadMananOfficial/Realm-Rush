using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
	[SerializeField] Transform defendorPrefab;
	
	[SerializeField] bool isPlaceable;
	public bool IsPlaceable{get {return isPlaceable;} }
	
	
	void OnMouseDown()
	{
		if(isPlaceable)
		{
			Instantiate(defendorPrefab,transform.position,Quaternion.identity);
			isPlaceable = false;
		}
	}
}
