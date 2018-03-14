﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager10 : SManager
{

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
    void Start()
    {
        Rbutton.SetActive(false);
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


    public override void OnMouseDown(GameObject go)
    {

        base.OnMouseDown(go); if (go.name == "tap")
        {
            animatorTap.SetTrigger("tapme");

            animatorTap.SetBool("zoom", true);

            tapActive = true;
            shakeStop();

            //animatorTap.SetBool("zoom", false);
            //animatorMe.SetBool("zoom", false);

        }
        else if (go.name == "me")
        {
            animatorMe.SetTrigger("tapme");

            animatorMe.SetBool("zoom", true);

            tapActive = true;
            shakeStop();


        }

        if (go.name == "redFrog")
        {
            Destroy(go);
            frogAnim.SetActive(true);
            StartCoroutine(StartSceneTransitionListener());
        }
        else if (go.name == "yellowFrog" || go.name == "greenFrog")
        {
            Destroy(go);
        }

    }
    private IEnumerator StartSceneTransitionListener()
    {
        yield return new WaitForSeconds(0.8f);
        NextScene();
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
    }
}
