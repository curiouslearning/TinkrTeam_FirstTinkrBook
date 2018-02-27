using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager20 : SManager {


	public TinkerGraphic sheet;
	public GameObject target;
	private Vector2 currentPos, targetPos;
	float distance;
	bool dragActivated = false;

	void Start () {
		distance = 0.1f;   //change according to your need
		if (sheet != null) {
			sheet.SetDraggable(true);
			currentPos = sheet.GetCoordinates ();

			targetPos = target.transform.position;
			Debug.Log ("target position:" + targetPos);
		}
	}


	public override void OnDragBegin(TinkerGraphic graphic)
	{
		if (graphic.GetDraggable ()) {
			dragActivated = true;         //for hint playing    
			sheet.MoveObject (); 
		}
	}
	public override void OnDrag(TinkerGraphic graphic)
	{
			if (graphic.GetDraggable ()) {
				sheet.MoveObject ();
			}
	}
	public override void OnDragEnd(TinkerGraphic graphic)
	{
			if (graphic.GetDraggable ()) {
		    	currentPos = sheet.GetCoordinates();
	     		bool navigate= CheckNear (targetPos, currentPos, distance);
			    if(navigate){
				    sheet.transform.position = targetPos;   
			     	NextScene ();
			    }
		   }
	}
}
