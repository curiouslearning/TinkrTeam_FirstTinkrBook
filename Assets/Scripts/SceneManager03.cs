using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager03 : SManager {


	public TinkerGraphic topShell;
	private Vector2 initialPos, finalPos;
	float distance;

	// write func in SManager for checking boundary
	void Start () {
		distance= 0.6f;   //change according to your need
		if (topShell != null) {
			topShell.SetDraggable(true);
			initialPos = topShell.GetCoordinates ();
		}
	}
		

	public override void OnDrag(TinkerGraphic graphic)
	{
			if (graphic.GetDraggable ()) {
				topShell.MoveObject ();
			}
	}
	public override void OnDragEnd(TinkerGraphic graphic)
	{
			if (graphic.GetDraggable ()) {
				finalPos = topShell.GetCoordinates();
				bool navigate= CalculateDistance (initialPos, finalPos, distance);
				if(navigate){
					NextScene ();
				}
			}
	}
}
