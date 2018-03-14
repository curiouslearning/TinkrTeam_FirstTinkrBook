using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager03 : SManager {

	public TinkerGraphic topShell;
	private Vector2 initialPos, finalPos;
	float distance, hintDelayTime, animationLength;

	public GameObject hintObject;

    public GameObject help;
    private static Animator animatorTap;
    public static bool tapActive = false;
    public bool autoPlayingDoneNow = false;
    public bool playingWasActive = false;

    void Start () {
		distance = 1.0f;   //change according to your need
		hintDelayTime = 2.0f;
		animationLength = 2.0f;
		if (topShell != null) {
			topShell.SetDraggable(true);
			initialPos = topShell.GetCoordinates ();
		}
        animatorTap = help.GetComponent<Animator>();
        
        StartCoroutine(Shake());
        StartCoroutine (StartHintManager());
	}
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.33f);

        sync();

    }
    IEnumerator Shake()
    {
        while (true)
        {
            Debug.Log(tapActive);
            

            if (stanzaManager.IsAutoPlaying())
            {
                shakeStop();
                autoPlayingDoneNow = false;
                playingWasActive = true;
            }
            if (!stanzaManager.IsAutoPlaying() && playingWasActive)
            {
                autoPlayingDoneNow = true;
            }
            if (autoPlayingDoneNow)
            {
                shakeStart();
                autoPlayingDoneNow = false;
            }

            if (!tapActive && !stanzaManager.IsAutoPlaying())
            {

                if (animatorTap.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                {
                    Debug.Log("shake start");
                    shakeStart();
                }
            }

            yield return new WaitForSeconds(0.3f);


        }
    }
    public override void OnMouseCurrentlyDown(GameObject go)
    {
        base.OnMouseCurrentlyDown(go);

        if (go.name == "help")
        {
            tapActive = true;
            animatorTap.SetBool("zoom", true);
        }
        
    }
    public override void OnMouseUp(GameObject go)
    {
        base.OnMouseUp(go);

        if (go.name == "help")
        {
            tapActive = false;
            animatorTap.SetBool("zoom", false);
        }
        
        StartCoroutine(WaitTime());
    }


    public override void OnMouseDown(GameObject go)
    {

        base.OnMouseDown(go);
        if (go.name == "help")
        {
            Debug.Log("tapactive stage");
            animatorTap.SetTrigger("tapme");

            animatorTap.SetBool("zoom", true);

            tapActive = true;
            shakeStop();
            
        }
       
    }
    

    public void shakeStop()
    {
        Debug.Log("stopShake");
        animatorTap.ResetTrigger("shake");
    }

    public void shakeStart()
    {
        animatorTap.speed = 1.0f;
        if (animatorTap.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            animatorTap.Play("idle");

            animatorTap.SetTrigger("shake");
        }
    }
    public static void sync()
    {
        animatorTap.Rebind();
    }

    public override IEnumerator StartHintManager()
	{
		//implement a delay at start

		while (true)
		{
			yield return new WaitForSeconds(hintDelayTime);
      
			if (!(stanzaManager.IsAutoPlaying() || dragActive))      // if drag is activate, don't play hints!
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
			dragActive = true;     //active only DURING frag active
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
