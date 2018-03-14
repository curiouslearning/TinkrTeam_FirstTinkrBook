using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SManager :  MonoBehaviour {


	[HideInInspector]
	public GameManager gameManager;

	// Manager for all TinkerTexts and stanza
	public StanzaManager stanzaManager;
	public List<Stanza> stanzas;
	public GameObject Lbutton;
	public GameObject Rbutton;

	// Whether to allow input on text/graphics during autoplay
	public bool inputAllowedDuringAutoplay = true;

	// Whether to interrupt auto play if a single word is hit
	public bool inputInterruptsAutoplay = true;

	// Disable auto play?
	[HideInInspector]
	public bool disableAutoplay = false;

	// Disable sounds?
	[HideInInspector]
	public bool disableSounds = false;

	// Drag event active?
	[HideInInspector]
	public bool dragActive = false;

	void Start () { 

	}
	//override me
	public virtual void Update() {
	}


	public virtual void Init(GameManager _gameManager)
	{
		gameManager = _gameManager;

		// Reset flags
		dragActive = false;
		disableAutoplay = false;
		disableSounds = false;

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


	public bool IsInputAllowed()
	{
		if (inputAllowedDuringAutoplay)
		{
			return true;
		}
		else if (stanzaManager != null)
		{
			return !stanzaManager.IsAutoPlaying();   
		}

		return true; // stanza manager must be null
	}
	// Here we have a superclass intercept for catching global GameObject mouse down events
	public virtual void OnMouseDown(GameObject go)
	{
		// Lock out other input during auto play?
		if (IsInputAllowed())
		{
			// TinkerText object 
			if (go.GetComponent<TinkerText>() != null)
			{
				TinkerText tinkerText = go.GetComponent<TinkerText>();

				if (tinkerText != null)
				{
					if (stanzaManager != null)
					{
						// Is an autoplay in progress? If so, see if we should interrupt
						if (stanzaManager.IsAutoPlaying() && inputInterruptsAutoplay)
						{
							stanzaManager.RequestCancelAutoPlay();
						}

						stanzaManager.OnMouseDown(tinkerText);
					}
				}
			}
			// TinkerGraphic object
			else if (go.GetComponent<TinkerGraphic>() != null)
			{
				TinkerGraphic tinkerGraphic = go.GetComponent<TinkerGraphic>();

				if (tinkerGraphic != null)
				{
					tinkerGraphic.OnMouseDown();
				}
			}
		}
	}

	// Here we have a superclass intercept for catching global TinkerGraphic mouse down events
	public virtual void OnMouseDown(TinkerGraphic tinkerGraphic)
	{
		if (tinkerGraphic.pairedText1 != null)
		{
			stanzaManager.OnPairedMouseDown(tinkerGraphic.pairedText1);
		}
	}

	// Here we have a superclass intercept for catching global TinkerText paired mouse down events
	public virtual void OnPairedMouseDown(TinkerText tinkerText)
	{
		Renderer[] list;
		list = tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer item in list){
			if (item.name == "ripple")
				continue;
			item.material.color = tinkerText.pairedGraphic.highlightColor;
		 }
       
	}

	// Here we have a superclass intercept for catching global GameObject mouse currently down events
	public virtual void OnMouseCurrentlyDown(GameObject go)
	{
		// Lock out other input during auto play?
		if (IsInputAllowed())
		{
			// TinkerGraphic object
			if (go.GetComponent<TinkerGraphic>() != null)
			{
				TinkerGraphic tinkerGraphic = go.GetComponent<TinkerGraphic>();

				if (tinkerGraphic != null)
				{
					tinkerGraphic.OnMouseCurrentlyDown();
				}
			}
			// TinkerText object
			else if (!dragActive && go.GetComponent<TinkerText>() != null)
			{
				TinkerText tinkerText = go.GetComponent<TinkerText>();

				if (tinkerText != null)
				{
					if (stanzaManager != null)
					{
						// Only allow further drag events if we aren't autoplaying
						if (!stanzaManager.IsAutoPlaying())
						{
							stanzaManager.OnMouseCurrentlyDown(tinkerText);
						}
					}
				}
			}
		}
	}

	// Here we have a superclass intercept for catching global TinkerGraphic mouse currently down events
	public virtual void OnMouseCurrentlyDown(TinkerGraphic tinkerGraphic)
	{
		// override me
	}

	// Here we have a superclass intercept for catching global TinkerText paired mouse currently down events
	public virtual void OnPairedMouseCurrentlyDown(TinkerText tinkerText)
	{
		// override me
	}

	// Here we have a superclass intercept for catching global GameObject mouse up events
	public virtual void OnMouseUp(GameObject go)
	{
		// Got a TinkerText object? (Also, make sure dragActive is false)
		if (!dragActive && go.GetComponent<TinkerText>() != null)
		{
			TinkerText tinkerText = go.GetComponent<TinkerText>();

			if (tinkerText != null)
			{
				if (stanzaManager != null)
				{
					stanzaManager.OnMouseUp(tinkerText);
				}
			}
		}
		// TinkerGraphic object
		else if (go.GetComponent<TinkerGraphic>() != null)
		{
			TinkerGraphic tinkerGraphic = go.GetComponent<TinkerGraphic>();

			if (tinkerGraphic != null)
			{
				tinkerGraphic.MyOnMouseUp();
			}
		}
	}

	// Here we have a superclass intercept for catching global TinkerGraphic mouse up events
	public virtual void OnMouseUp(TinkerGraphic tinkerGraphic)
	{
		// override me
	}

	// Here we have a superclass intercept for catching global TinkerText paired mouse up events
	public virtual void OnPairedMouseUp(TinkerText tinkerText)
	{
		Renderer[] list;
		list = tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer item in list){   //color all the components
			item.material.color = tinkerText.pairedGraphic.resetColor;
		}
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
		

	//UI Right Button 
	public void NextScene()
	{
		gameManager.LoadNextScene();
	}

	//UI Left Button
	public void PreviousScene()
	{
		gameManager.LoadPreviousScene();
	}

	public virtual void ResetInputStates(GameManager.MouseEvents mouseEvent)
	{
		if (stanzaManager != null)
		{
			stanzaManager.ResetInputStates(mouseEvent);
		}
	}

	public bool CheckFar(Vector2 start, Vector2 end, float requiredDistance){
		if (requiredDistance <= Vector2.Distance (start, end)) {
			return true;
		}
		return false;
	}

	public bool CheckNear(Vector2 start, Vector2 end, float requiredDistance){
		if (requiredDistance >= Vector2.Distance (start, end)) {
			return true;
		}
		return false;
	}


}