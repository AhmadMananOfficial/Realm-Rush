using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	
	[SerializeField] List<WayPoint> Path = new List<WayPoint>();
	[SerializeField] int delayTime = 1; 
	
    void Start()
    {
	    StartCoroutine(FollowPath());
    }

    
	IEnumerator FollowPath()
    {
	    foreach(WayPoint waypoint in Path)
	    {
	    	transform.position = waypoint.transform.position;
	    	yield return new WaitForSeconds(delayTime);
	    }
    }
}
