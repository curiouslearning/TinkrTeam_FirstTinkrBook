using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager20 : SManager {

	// Use this for initialization
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
		if (go.tag == "graphic") {
			TinkerGraphic tinkerGraphic = go.GetComponent<TinkerGraphic> ();
			if (GameObject.ReferenceEquals(sheet,tinkerGraphic)) {
				//check draggable
			} 
		}
	}

	public override void OnDrag(TinkerGraphic graphic)
	{
		if (GameObject.ReferenceEquals(sheet, graphic)) {
			if (sheet.GetDraggable ()) {
				sheet.MoveObject ();
			}
		} 
	}
	public override void OnDragEnd(TinkerGraphic graphic)
	{
		if (GameObject.ReferenceEquals(sheet, graphic)) {
			if (sheet.GetDraggable ()) {
				Vector3 position = sheet.GetCoordinates();
				Debug.Log ("position:" + position);
			}
		} 
	}
}
