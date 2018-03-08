using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager03 : SManager {

	public TinkerGraphic topShell;
	private Vector2 initialPos, finalPos;
	float distance, hintDelayTime, animationLength;
	bool dragActivated = false;
	public GameObject animObject;

	void Start () {
		distance = 1.0f;   //change according to your need
		hintDelayTime = 2.0f;
		animationLength = 2.0f;
		if (topShell != null) {
			topShell.SetDraggable(true);
			initialPos = topShell.GetCoordinates ();
		}
		StartCoroutine (StartHintManager());
	}

   public override IEnumerator StartHintManager()
	{
		//implement a delay at start

		while (true)
		{
			yield return new WaitForSeconds(hintDelayTime);
      
			if (!(stanzaManager.IsAutoPlaying() || dragActivated))      // if drag is activated even once, don't play hints!
			{
				yield return StartCoroutine(PlayHintAnimation());
			}
		}
	}

	public override IEnumerator PlayHintAnimation()
	{
			animObject.SetActive (true);
			yield return new WaitForSeconds(animationLength);
	    	animObject.SetActive (false);
			yield return new WaitForSeconds(hintDelayTime);
	}
		

	// Scene specific override (when play clicks on top shell, make it stick to wherever they move)
	public override void OnMouseDown(TinkerGraphic tinkerGraphic)
	{
		base.OnMouseDown(tinkerGraphic);
		if (tinkerGraphic.GetDraggable ()) {
			dragActive = true;     //active only DURING frag active
			dragActivated = true;  //activated for even a single drag
		} 
	}

	// Scene specific override (when play clicks on top shell, make it stick to wherever they move)
	public override void OnMouseCurrentlyDown(TinkerGraphic tinkerGraphic)
	{
		base.OnMouseCurrentlyDown(tinkerGraphic);

		if (dragActive)
		{
			if (tinkerGraphic.GetDraggable ()) {
				topShell.MoveObject ();
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

			// See if player has moved shell far enough away to advance the scene
			finalPos = topShell.GetCoordinates();
			bool navigate= CheckFar (initialPos, finalPos, distance);
			if(navigate){
				NextScene ();
			}
		}
	}
}
