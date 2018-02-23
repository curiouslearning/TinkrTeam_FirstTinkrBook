using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager02 : SManager {
    public GameObject tap;
    public GameObject me;
    bool tapActive = false;
    // Use this for initialization
    void Start () {
		
	}

    public override void Update()
    {


        //StartCoroutine(Example())
        if (!tapActive)
        {
            tap.GetComponent<Animator>().SetTrigger("shake");
            me.GetComponent<Animator>().SetTrigger("shake");
        }
        tap.GetComponent<Animator>().speed = 1f;
        me.GetComponent<Animator>().speed = 1f;

        if (tap.GetComponent<Animator>().GetBool("tapme") == true) {
            tapActive = true;
            //StartCoroutine(Example());
            //tap.GetComponent<Animator>().SetActive
            tap.GetComponent<Animator>().ResetTrigger("shake");
            me.GetComponent<Animator>().ResetTrigger("shake");

        }

    }
   

    IEnumerator Example()
    {
        yield return new WaitForSeconds(10000);
        
    }
}
