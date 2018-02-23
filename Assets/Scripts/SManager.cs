using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SManager : MonoBehaviour {


    [HideInInspector]
    public GameManager gameManager;

    // Manager for all TinkerTexts and stanza
    public StanzaManager stanzaManager;
    public List<Stanza> stanzas;
    public GameObject Lbutton;
    public GameObject Rbutton;
    public GameObject L1button;
    public GameObject R1button;

    public bool disableAutoplay;

    void Start () { 
        Lbutton.SetActive(false);
        Rbutton.SetActive(false);
		L1button.SetActive(true);
        R1button.SetActive(false);

    }
    //override me
    public virtual void Update() {
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
	public virtual void OnDragBegin(TinkerGraphic graphic){


	}
	//override me
	public virtual void OnDrag(TinkerGraphic graphic){
	     
	    
	}
	//override me
	public virtual void OnDragEnd(TinkerGraphic graphic){


	}

	// Override if a scene manager subclass needs a hint manager
	public virtual IEnumerator StartHintManager()
	{
		yield break;
	}

	// Override if a scene manager subclass needs a graphic hint
	public virtual IEnumerator PlayHintAnimation()
	{
		yield break;
	}

    // override me
    public virtual void OnPointerClick(GameObject cl)
    {


        //if (cl.name == "yellow")
        //{
        //    R1button.SetActive(true);
        //}
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
        if (go.tag == "text")
        {
            stanzaManager.OnMouseDown(go.GetComponent<TinkerText>());

        }
		else if (go.tag=="graphic") {
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
    

	public void NextScene()
	{
		gameManager.LoadNextScene();
	}

	public void PreviousScene()
	{
		gameManager.LoadPreviousScene();
	}

    // Here we have a superclass intercept for catching global TinkerGraphic mouse down events
    public virtual void OnMouseDown(TinkerGraphic tinkerGraphic)
    {

    }



	public bool CalculateDistance(Vector2 start, Vector2 end, float requiredDistance){
		if (requiredDistance <= Vector2.Distance (start, end)) {
			return true;
		}
		return false;
	}


}
