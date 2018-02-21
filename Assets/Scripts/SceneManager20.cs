using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager20 : SManager {


	public TinkerGraphic sheet;
	//public distance;  define the var and initialize in Start()
	// write func in SManager for checking boundary
	void Start () {
		//set the distance and draggable obj.
		if (sheet != null) {
			sheet.SetDraggable(true);
		}
	}
	
	public override void OnDragBegin(GameObject go)
	{
		
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
				Vector3 position = sheet.GetCoordinates();
				Debug.Log ("position:" + position);
			}
	}
}
