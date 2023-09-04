using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	
	[SerializeField] List<WayPoint> Path = new List<WayPoint>();
	[SerializeField] [Range(0f,5f)] float moveSpeed = 1; 
	
	void OnEnable()
	 {
		 FindPath();
		 SetEnemyAtStart();
	    StartCoroutine(FollowPath());
	 }
    
	void SetEnemyAtStart()
	{
		transform.position = Path[0].transform.position;
	}

	void FindPath()
	{
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
		
		foreach(GameObject wayPoint in waypoints)
		{
			Path.Add(wayPoint.GetComponent<WayPoint>());
		}
	}
    
	IEnumerator FollowPath()
	{
	    foreach(WayPoint waypoint in Path)
	    {
	    	 Vector3 startPoint = transform.position;
		    Vector3 endPoint = waypoint.transform.position;
		    float travelTime = 0f;
		    
		    transform.LookAt(endPoint);
		    
		    while(travelTime < 1f)
		    {
		    	travelTime += Time.deltaTime * moveSpeed;
		    	transform.position = Vector3.Lerp(startPoint, endPoint, travelTime);
		    	yield return new WaitForEndOfFrame();
		    }
	    }
	    
		gameObject.SetActive(false);
    }
}
