using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneManager02 : SManager
{
    public GameObject tap;
    public GameObject me;
    public GameObject eggCrack;
    public GameObject eggCrackLastClip;
    private static Animator animatorTap;
    private static Animator animatorMe;
    public static bool tapActive = false;
    public bool autoPlayingDoneNow = false;
    public bool playingWasActive = false;
    bool imageClicked = false;

	public override void Start() {
		base.Start ();
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

    IEnumerator WaitTime2()
    {
        yield return new WaitForSeconds(1.0f);
       
        animatorTap.SetTrigger("shake");
        animatorMe.SetTrigger("shake");
    }
    //IEnumerator WaitTime3(float a)
    //{
    //    yield return new WaitForSeconds(a);
    //    animatorMe.Play("nmscale");
    //    animatorTap.Play("nmscale");
    //}

    IEnumerator Shake()
    {
        while (true)
        {
            animatorTap.speed = 1.0f;
            animatorMe.speed = 1.0f;
           
            if (stanzaManager.IsAutoPlaying())
            {
                shakeStop();
                autoPlayingDoneNow = false;
                playingWasActive = true;
            }
            if (!stanzaManager.IsAutoPlaying() && playingWasActive)
            {
                //call mouse down
                Debug.Log("entered2");
               

                playingWasActive = false;
                autoPlayingDoneNow = true;
            }
            if (autoPlayingDoneNow)
            {
                //sync();   
                if ((animatorMe.GetCurrentAnimatorStateInfo(0).IsName("idle") && animatorMe.GetCurrentAnimatorStateInfo(0).normalizedTime == 1 && !animatorMe.IsInTransition(0)) && (animatorTap.GetCurrentAnimatorStateInfo(0).IsName("idle") && animatorTap.GetCurrentAnimatorStateInfo(0).normalizedTime == 1 && !animatorMe.IsInTransition(0)))
                {

                    shakeStart();
                }
                autoPlayingDoneNow = false;
            }
            if (!tapActive && !imageClicked && !stanzaManager.IsAutoPlaying())
            {
                //if ((animatorMe.GetCurrentAnimatorStateInfo(0).IsName("idle") && animatorMe.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animatorMe.IsInTransition(0)) && (animatorTap.GetCurrentAnimatorStateInfo(0).IsName("idle") && animatorTap.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animatorMe.IsInTransition(0)))
                if (animatorMe.GetCurrentAnimatorStateInfo(0).IsName("idle") && animatorTap.GetCurrentAnimatorStateInfo(0).IsName("idle"))
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
    public override void OnMouseDown(GameObject go)
    {

        base.OnMouseDown(go);
        if (go.name == "tap")
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
        else if (go.name == "eggcrack")
        {
            imageClicked = true;
            eggCrack.SetActive(false);
            eggCrackLastClip.SetActive(true);
            animatorMe.ResetTrigger("shake");
            animatorTap.ResetTrigger("shake");
            StartCoroutine(WaitTimeAndLoadNextScene());
        }

    }
    public static void sync()
    {
        animatorMe.Rebind();
        animatorTap.Rebind();
    }
    public void shakeStop()
    {
        Debug.Log("stopShake");
        //animatorMe.Play("idle");
        //animatorTap.Play("idle");
        animatorTap.ResetTrigger("shake");
        animatorMe.ResetTrigger("shake");
    }
    public void shakeStart()
    {
        animatorTap.speed = 1.0f;
        animatorMe.speed = 1.0f;
        //if(animatorTap.GetComponent<Animation>().isActiveAndEnabled)
        //StartCoroutine(WaitTime2());
        //if (animatorMe.GetCurrentAnimatorStateInfo(0).IsName("shake") && animatorTap.GetCurrentAnimatorStateInfo(0).IsName("shake"))
        //{
        //    Debug.Log("do nothing");
        //}
        //else
        //{
        //    animatorMe.Play("idle");
        //    animatorTap.Play("idle");
        if (animatorMe.GetCurrentAnimatorStateInfo(0).IsName("idle") && animatorTap.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            animatorMe.Play("idle");
            animatorTap.Play("idle");
            animatorTap.SetTrigger("shake");
            animatorMe.SetTrigger("shake");
        }

        //}

        // StartCoroutine(WaitTime2(animatorMe.GetCurrentAnimatorStateInfo(0).length));

        // StartCoroutine(WaitTime3(animatorMe.GetCurrentAnimatorStateInfo(0).length));
        //Debug.Log("Length "+animatorMe.GetCurrentAnimatorStateInfo(0).length);

    }
}