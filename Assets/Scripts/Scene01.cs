using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scene01:SManager {
    private Animator hintanimator;
    void Start()
    {
        hintanimator = GetComponent<Animator>();


    }
	public override void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            return;
        }
        StartCoroutine(playanimwithaloophelper(2));

    }

    //Implement a function to play an animation with a time delay in a loop until a desired action occurs
    public void playanimwithaloop(float del)
    {
        //play anim loop untill desired action i.e key press occurs.
        while (Input.GetKeyDown(KeyCode.A) == false)
        {
            //if (Input.GetKeyDown(KeyCode.A)) {
            //    break;
            //}
            StartCoroutine(playanimwithaloophelper(del));
        }
    }

    private IEnumerator playanimwithaloophelper(float del)
    {
        //graphicPlay();
        yield return new WaitForSeconds(del);
    }

    public void hintgraphicPlay()
    {


    }
}
