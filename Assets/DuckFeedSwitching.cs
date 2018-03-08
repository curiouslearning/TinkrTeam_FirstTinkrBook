using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFeedSwitching : MonoBehaviour {

	public GameObject duckIdle;
	public GameObject duckChew;
	public GameObject duckMouthOpen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{    Debug.Log ("collision called");
		duckIdle.SetActive (false);
		duckMouthOpen.SetActive (true);
	}
}
