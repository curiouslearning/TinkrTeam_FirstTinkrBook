using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckBugFeedSwitching : MonoBehaviour {

	public GameObject duckIdle;
	public GameObject duckChew;
	public GameObject duckMouthOpen;
	public GameObject bugInMouth;
	public GameObject handHint;
	public int bugCounter;
	public SManager sceneManager;
	public Text num;

	// Use this for initialization
	void Start () {
		bugCounter = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//num.text = bugCounter.ToString();
		
	}

	void OnTriggerEnter(Collider collider)
	{   
		num.text = bugCounter.ToString ();
		duckIdle.SetActive(false);  
		duckChew.SetActive (false);
		duckMouthOpen.SetActive (true); //mouth open
		bugInMouth = collider.gameObject;
		Debug.Log (bugInMouth);
	}

	void OnTriggerExit(Collider collider)
	{
		bugInMouth = null;
		duckIdle.SetActive (true);
		duckMouthOpen.SetActive (false);
		duckChew.SetActive (false);
	}

	public void FeedDuckOnMouseDown()
	{   
		num.text = bugCounter.ToString ();
	}

	public void FeedDuckOnMouseCurrentlyDown()
	{  
		num.text = bugCounter.ToString ();
	}

	public void FeedDuckOnMouseUp()
	{   num.text = "";
		if (bugInMouth) {
			Destroy (bugInMouth);
			handHint.SetActive (false);
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

