using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TinkerGraphic : MonoBehaviour {
    private Animator anim;
    public TinkerText pairedtext1;
    public TinkerText pairedtext2;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        
    }
	// Update is called once per frame
	void Update () {
		
	}
   
    public void OnMouseDown()
    {
        //if (pairedTinkerText != null)
        //    TinkerText.pairedgraphic = true;

        //Debug.Log("tinker graphic paired "+TinkerText.pairedgraphic);
        graphicPlay();
     
    }
    public void OnMouseUp()
    {
        graphicResume();
        //TinkerText.pairedgraphic = false;
    }
    public void graphicPlay()
    {
        if (anim != null)
        {
            if (TinkerText.nooftaps < 3)
            {
                pairedtext1.clipPlay();
                int i = TinkerText.nooftaps + 1;
                anim.SetTrigger("crack" + i);

            }
            else
            {
               // TinkerText.nooftaps--;
                if (pairedtext2 != null)
                {
                    pairedtext2.clipPlay();

                }
                anim.SetTrigger("crack3");

                //SceneManager.LoadScene("Scene02");
            }
        }
    }
    public void graphicResume()
    {
        if (TinkerText.nooftaps < 3)
        {
            Debug.Log("graphic resumed "+TinkerText.nooftaps);
            if (pairedtext1 != null)
                pairedtext1.clipResume();
            TinkerText.nooftaps++;

        }
        else
        {
            if (pairedtext2 != null)
                pairedtext2.clipResume();
            TinkerText.nooftaps = 0;
        }
    }
    //public void clipPlay() {

    //if (anim != null)
    //{
    //    //if (TinkerText.nooftaps < 2)
    //    //{
    //    //    int i = TinkerText.nooftaps + 1;
    //        anim.SetTrigger("crack" + i);
    //        //TinkerText.nooftaps++;
    //        Debug.Log("tapcountgraphic: " + TinkerText.nooftaps);

    //    //}
    //    else
    //    {
    //        anim.SetTrigger("crack3");
    //        SceneManager.LoadScene("Scene02");
    //    }
    //}


    //  }



}
