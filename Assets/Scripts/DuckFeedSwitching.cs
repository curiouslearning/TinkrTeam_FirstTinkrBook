using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckFeedSwitching : MonoBehaviour {

	public GameObject duckIdle;
	public GameObject duckChew;
	public GameObject duckMouthOpen;
	public GameObject bugInMouth;
	public int bugCounter;
	public SManager sceneManager;
	// Use this for initialization
	void Start () {
		bugCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider)
	{   
		Debug.Log ("collision called");
		duckIdle.SetActive(false);  
		duckChew.SetActive (false);
		duckMouthOpen.SetActive (true); //mouth open
		bugInMouth = collider.gameObject;
	}

	void OnTriggerExit(Collider collider)
	{
		bugInMouth = null;
		duckIdle.SetActive (true);
		duckMouthOpen.SetActive (false);
		duckChew.SetActive (false);
	}

	public void FeedDuckOnMouseUp()
		{
		if (bugInMouth) {
			Destroy (bugInMouth);
			duckMouthOpen.SetActive (false);
			duckChew.SetActive (true);
			bugCounter++;
			if (bugCounter == 8) {
				sceneManager.NextScene ();
			}
		}
		    // chew on mouse up on gameobject
			StartCoroutine (SetChewFalse());
			
		}

	 public IEnumerator SetChewFalse()
		{yield return new WaitForSeconds (1.0f);
		duckChew.SetActive (false);
		duckIdle.SetActive (true);
			
		}
	}

