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
	[SerializeField] Color exploredColor = Color.yellow;
	[SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

	TextMeshPro labelText;
	Vector2Int coordinates = new Vector2Int();
	
	GridManager gridManager;
    
	 void Awake()
    {
	    labelText = GetComponent<TextMeshPro>();
	    labelText.enabled = false;
	    
	    gridManager = FindObjectOfType<GridManager>();
	    
	    DisplayCoordinates();
    }

    
    void Update()
	{
		if(!Application.isPlaying)
		{
			DisplayCoordinates();
			UpdateObjectName();
			
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
		if(gridManager == null) { return; }

		Node node = gridManager.GetNode(coordinates);

		if(node == null) { return; }

		if(!node.isWalkable)
		{
			labelText.color = blockedColor;
		}
		else if(node.isPath)
		{
			labelText.color = pathColor;
		}
		else if(node.isExplored)
		{
			labelText.color = exploredColor;
		}
		else
		{
			labelText.color = defaultColor;
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
