using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
	
	[SerializeField] List<WayPoint> Path = new List<WayPoint>();
    
    void Start()
    {
	    PrintWayPointName();
    }

    
	 void PrintWayPointName()
    {
	    foreach(WayPoint waypoint in Path)
	    {
	    	Debug.Log(waypoint.name);
	    }
    }
}
