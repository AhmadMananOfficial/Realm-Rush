using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabler : MonoBehaviour
{
	[SerializeField] Color defaultColor = Color.white;
	[SerializeField] Color blockedColor = Color.gray;
	
	TextMeshPro labelText;
	Vector2Int coordinates = new Vector2Int();
	
	WayPoint wayPoint;
    
	 void Awake()
    {
	    labelText = GetComponent<TextMeshPro>();
	    labelText.enabled = false;
	    
	    wayPoint = GetComponentInParent<WayPoint>();
	    
	    DisplayCoordinates();
    }

    
    void Update()
	{
		if(!Application.isPlaying)
		{
			DisplayCoordinates();
			UpdateObjectName();
			labelText.enabled = true;
		}
	    
		ToogleVisible();
		SetLabelTextColor();
	}
	
	void ToogleVisible()
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
			labelText.enabled = !labelText.IsActive();
		}
	}
    
	void SetLabelTextColor()
	{
		if(wayPoint.IsPlaceable)
		{
			labelText.color = defaultColor;
		}
		else
		{
			labelText.color = blockedColor;
		}
	}
    
	void DisplayCoordinates()
	{
		coordinates.x = Mathf.RoundToInt(transform.parent.position.x /UnityEditor.EditorSnapSettings.move.x);
		coordinates.y = Mathf.RoundToInt(transform.parent.position.z /UnityEditor.EditorSnapSettings.move.z);
		
		labelText.text = coordinates.x + "," + coordinates.y;		
	}
	
	void UpdateObjectName()
	{
		transform.parent.name = coordinates.ToString();
	}
}
