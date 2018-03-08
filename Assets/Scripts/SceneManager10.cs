using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager10 : SManager {

	public GameObject frogAnim;
	// Use this for initialization
	void Start () {
		Rbutton.SetActive (false);
	}

	public override void OnMouseDown(GameObject go){

		base.OnMouseDown (go);
		if (go.name == "redFrog") {
			Destroy (go); 
			frogAnim.SetActive (true);
			StartCoroutine(StartSceneTransitionListener ());
		} else if (go.name == "yellowFrog" || go.name == "greenFrog") {
			Destroy (go); 
		}
	}
	private IEnumerator StartSceneTransitionListener(){
			yield return new WaitForSeconds (1.0f);
			NextScene ();
	}
}
