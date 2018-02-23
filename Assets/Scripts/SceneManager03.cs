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
		distance = 0.6f;   //change according to your need
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

			if (!(stanzaManager.IsAutoPlaying() || dragActivated))
			{
				Debug.Log ("Start hint: "+dragActivated);
				yield return StartCoroutine(PlayHintAnimation());
			}
		}
	}

	public override IEnumerator PlayHintAnimation()
	{
			animObject.SetActive (true);
			animObject.GetComponent<Animator> ().Play ("init_tap_anim");
			yield return new WaitForSeconds(animationLength);
	    	animObject.SetActive (false);
			yield return new WaitForSeconds(hintDelayTime);
	}

	public override void OnDragBegin(TinkerGraphic graphic){
		if (graphic.GetDraggable ()) {
			dragActivated = true;
			topShell.MoveObject ();
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
			   // dragActivated = false;
				finalPos = topShell.GetCoordinates();
				bool navigate= CalculateDistance (initialPos, finalPos, distance);
				if(navigate){
					NextScene ();
				}
			}
	}
}
