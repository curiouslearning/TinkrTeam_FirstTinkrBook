using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SManager : MonoBehaviour {
    [HideInInspector]
    public GameManager gameManager;

    // Manager for all things TinkerText
    public StanzaManager stanzaManager;
    public List<Stanza> stanzas;
    public GameObject Lbutton;
    public GameObject Rbutton;
    public GameObject L1button;
    public GameObject R1button;

    public bool disableAutoplay;
    //public TinkerText tinkerText;

    // Use this for initialization
    void Start () {
       // if (L1button != null) 
        Lbutton.SetActive(false);
        Rbutton.SetActive(false);
		L1button.SetActive(true);
       // if(R1button!=null)
        R1button.SetActive(false);

    }
    public virtual void Init(GameManager _gameManager)
    {
        gameManager = _gameManager;
        disableAutoplay = false;

        // If we have a stanza manager
        if (stanzaManager != null)
        {
            // And it has an audio clip and xml defined already in the scene
            if (stanzaManager.xmlStanzaData != null && stanzaManager.GetComponent<AudioSource>().clip != null)
            {
                // Then have it set the xml up
                stanzaManager.LoadStanzaXML();
            }
        }
    }
    public virtual void OnDragBegin(GameObject go)
    {
		if (go.tag == "text") {
			stanzaManager.LoadStanzaXML ();
			if (stanzaManager == null) {
				stanzaManager = GameObject.Find ("StanzaManager").GetComponent<StanzaManager> ();
			}
			if (stanzaManager != null)
				stanzaManager.OnDragBegin (go.GetComponent<TinkerText> ());
		} 
			
    }

	//override me
	public virtual void OnDrag(TinkerGraphic graphic){
	     
	    
	}
	//override me
	public virtual void OnDragEnd(TinkerGraphic graphic){


	}
    public virtual void OnPointerClick(GameObject cl)
    {
		Debug.Log ("on pointer click smanager");
        if (cl.name == "Duck")
        {
            Debug.Log("duck called");
            gameManager.LoadNextScene();
        }

        if (cl.name == "yellow")
        {
			
            Debug.Log("yellow called");
            R1button.SetActive(true);
        }

    }
    public virtual void OnDragEnd()
    {
        if (stanzaManager != null)
        {
            stanzaManager.OnDragEnd();
        }

    }

   
    public virtual void OnMouseDown(GameObject go)
    {
        Debug.Log(go.tag);
        if (go.tag == "text")
        {
            stanzaManager.OnMouseDown(go.GetComponent<TinkerText>());

        }
		else if (go.tag=="graphic") {
            Debug.Log("graphic");
            stanzaManager.OnMouseDown(go.GetComponent<TinkerGraphic>());

        }

    }
    public virtual void OnMouseUp(GameObject go)
    {
         if(go.tag=="graphic"){
            stanzaManager.OnMouseUp(go.GetComponent<TinkerGraphic>());
        }
        if (go.tag == "text")
        {
            if (stanzaManager == null)
            {
                stanzaManager = GameObject.Find("StanzaManager").GetComponent<StanzaManager>();
            }
            if (stanzaManager != null)
            {
                stanzaManager.OnMouseUp(go.GetComponent<TinkerText>());
            }

        }

    }
    public void right()
    {
        Debug.Log("right clicked");
        gameManager.LoadNextScene();
    }
    public void left()
    {
        gameManager.LoadPreviousScene();
    }

    // Here we have a superclass intercept for catching global TinkerGraphic mouse down events
    public virtual void OnMouseDown(TinkerGraphic tinkerGraphic)
    {

    }

}
