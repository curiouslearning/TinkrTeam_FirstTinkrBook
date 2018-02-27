using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager02 : SManager
{
    public GameObject tap;
    public GameObject me;
    public GameObject Image;
    private static Animator animatortap;
    private static Animator animatorme;

    public static bool tapActive = false;
    bool imageClicked = false;

    void Start()
    {
        animatortap = tap.GetComponent<Animator>();
        animatorme = me.GetComponent<Animator>();

        StartCoroutine(Shake());
    }



    IEnumerator Example()
    {
        yield return new WaitForSeconds(10000);

    }
    IEnumerator Shake()
    {
        while (true)
        {
            if (!tapActive && !imageClicked)
            {
                //animatortap.GetComponent<Animation>().Play();
                //sync();
                shakeStart();


                //tapActive = false;


                //if(tapActive==true)
            }
            //tap.GetComponent<Animator>().speed = 1f;
            //animatorme.speed = 1f;

            if (animatortap.GetBool("zoom") == true || animatorme.GetBool("zoom") == true)
            {
                Debug.Log("tapactive stage");
                tapActive = true;

                shakeStop();
                //animatorme.speed = 0.0f;
                //animatortap.speed = 0.0f;
                //animatorme.StopPlayback();
                //animatorme.Rebind();
                //animatortap.Rebind();

                //animatorme.GetComponent<Animation>().Stop();

                //animatortap.GetComponent<Animation>().Stop();


                //shakeanim.GetComponent<Animation>().Stop();

                //animatorme.Rebind();
                //animatortap.Rebind();

                animatortap.SetBool("zoom", false);
                animatorme.SetBool("zoom", false);

            }
            //if released the tapactive=false;

            yield return new WaitForSeconds(1.0f);
            //dummy testing
            //for 3seconds me stops, on mouse up psr tapactive false krna tha but abhi timer lagaya hai

        }
    }

    public override void OnPointerClick(GameObject go)
    {
        if (go.name == "EggImage")
        {
            imageClicked = true;

            animatorme.ResetTrigger("shake");
            animatortap.ResetTrigger("shake");

        }
    }
    public static void sync()
    {
        //    SceneManager02 a = new SceneManager02();
        //    a.tap.GetComponent<Animator>().Rebind();
        animatorme.Rebind();
        //    a.me.GetComponent<Animator>().Rebind();

        animatortap.Rebind();

    }

    public void shakeStop()
    {
        Debug.Log("stop");
        animatortap.ResetTrigger("shake");
        animatorme.ResetTrigger("shake");
    }
    public void shakeStart()
    {
        animatorme.SetTrigger("shake");
        animatortap.SetTrigger("shake");
    }
}
