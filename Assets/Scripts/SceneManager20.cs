using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager20 : SManager {


	public TinkerGraphic sheet;
	public GameObject target;
	private Vector2 currentPos, targetPos;
	float distance, hintDelayTime, animationLength;
	public GameObject hintObject;

	void Start () {
		distance = 0.1f;   //change according to your need
		hintDelayTime = 2.0f;
		animationLength = 2.0f;
		if (sheet != null) {
			sheet.SetDraggable(true);
			currentPos = sheet.GetCoordinates ();
			targetPos = target.transform.position;
		}

		StartCoroutine (StartHintManager());
	}
		
	public override IEnumerator StartHintManager()
	{
		//implement a delay at start

		while (true)
		{
			yield return new WaitForSeconds(hintDelayTime);

			if (!(stanzaManager.IsAutoPlaying() || dragActive))      // if drag is active, don't play hint!
			{
				yield return StartCoroutine(PlayHintAnimation());
			}
		}
	}

	public override IEnumerator PlayHintAnimation()
	{
		hintObject.SetActive (true);
		yield return new WaitForSeconds(animationLength);
		hintObject.SetActive (false);
		yield return new WaitForSeconds(hintDelayTime);
	}


	// Scene specific override (when play clicks on top shell, make it stick to wherever they move)
	public override void OnMouseDown(TinkerGraphic tinkerGraphic)
	{
		base.OnMouseDown(tinkerGraphic);
		if (tinkerGraphic.GetDraggable ()) {
			dragActive = true;
		}
	}

	// Scene specific override (when play clicks on top shell, make it stick to wherever they move)
	public override void OnMouseCurrentlyDown(TinkerGraphic tinkerGraphic)
	{
		base.OnMouseCurrentlyDown(tinkerGraphic);
		if (dragActive)
		{
			if (tinkerGraphic.GetDraggable ()) {
				sheet.MoveObject ();
			}
		}
	}

	// Scene specific override (when play clicks on top shell, make it stick to wherever they move)
	public override void OnMouseUp(TinkerGraphic tinkerGraphic)
	{
		base.OnMouseUp(tinkerGraphic);

		if (dragActive && tinkerGraphic.GetDraggable() )
		{
			dragActive = false;
			// See if player has moved shell far away enough to advance the scene
			currentPos = sheet.GetCoordinates();
			bool navigate= CheckNear (targetPos, currentPos, distance);
			if (navigate) {
				Debug.Log (navigate);
				sheet.transform.position = targetPos;   
				NextScene ();
			}
		}
	}
}
