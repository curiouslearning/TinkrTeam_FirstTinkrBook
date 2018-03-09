using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager10 : SManager {

	public GameObject frogAnim;
    public GameObject tap;
    public GameObject me;
    private static Animator animatorTap;
    private static Animator animatorMe;
    public static bool tapActive = false;
    public bool autoPlayingDoneNow = false;
    public bool playingWasActive = false;
    bool imageClicked = false;
    // Use this for initialization
    void Start () {
		Rbutton.SetActive (false);
        animatorTap = tap.GetComponent<Animator>();
        animatorMe = me.GetComponent<Animator>();
        StartCoroutine(Shake());
    }
    IEnumerator WaitTimeAndLoadNextScene()
    {
        yield return new WaitForSeconds(2.33f);
        NextScene();
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
            Debug.Log(imageClicked);

            if (stanzaManager.IsAutoPlaying())
            {
                autoPlayingDoneNow = false;
                playingWasActive = true;
            }
            if (!stanzaManager.IsAutoPlaying() && playingWasActive)
            {
                autoPlayingDoneNow = true;
            }
            if (autoPlayingDoneNow)
            {
                sync();
                autoPlayingDoneNow = false;
            }

            if (!tapActive && !imageClicked && !stanzaManager.IsAutoPlaying())
            {

                if (animatorTap.GetCurrentAnimatorStateInfo(0).IsName("idle") && animatorMe.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                {
                    Debug.Log("shake start");
                    shakeStart();
                }
            }

            yield return new WaitForSeconds(0.3f);


        }
    }
    public override void OnMouseUp(GameObject go)
    {
        base.OnMouseUp(go);

        if (go.name == "tap")
        {
            tapActive = false;
            animatorTap.SetBool("zoom", false);
        }
        else if (go.name == "me")
        {
            tapActive = false;

            animatorMe.SetBool("zoom", false);
        }

        StartCoroutine(WaitTime());
    }
    public override void OnMouseCurrentlyDown(GameObject go)
    {
        base.OnMouseCurrentlyDown(go);

        if (go.name == "tap")
        {
            tapActive = true;
            animatorTap.SetBool("zoom", true);
        }
        else if (go.name == "me")
        {
            tapActive = true;
            animatorMe.SetBool("zoom", true);
        }
    }


    public override void OnMouseDown(GameObject go){

		base.OnMouseDown (go); if (go.name == "tap")
        {
            Debug.Log("tapactive stage");
            animatorTap.SetTrigger("tapme");

            animatorTap.SetBool("zoom", true);

            tapActive = true;
            shakeStop();

            //animatorTap.SetBool("zoom", false);
            //animatorMe.SetBool("zoom", false);

        }
        else if (go.name == "me")
        {
            Debug.Log("meactive stage");
            animatorMe.SetTrigger("tapme");

            animatorMe.SetBool("zoom", true);

            tapActive = true;
            shakeStop();


        }
       
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
    public static void sync()
    {
        animatorMe.Rebind();
        animatorTap.Rebind();
    }

    public void shakeStop()
    {
        Debug.Log("stopShake");
        animatorTap.ResetTrigger("shake");
        animatorMe.ResetTrigger("shake");
    }
    public void shakeStart()
    {

        animatorMe.SetTrigger("shake");
        animatorTap.SetTrigger("shake");
    }
}
