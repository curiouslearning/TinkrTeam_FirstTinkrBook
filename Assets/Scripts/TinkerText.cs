using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;

public class TinkerText : MonoBehaviour {
    //private static bool check=false;
    public TinkerText pairedTinkerText;
    public TinkerGraphic tinkerGraphic;
    public static bool pairedgraphic = false;
   // public Text tinkerText;
    public Stanza stanza;
    // Auto play timing related
    private float startTime;
    private float endTime;
    public float delayTime;
    //public GameObject text;
    private Animator wordanimator;
    private Animator iconanimator;
    private Animator graphicanimator;
    // private Animator animshit;
    public GameObject anim;
    //egg crack
    public GameObject anim2;
    public static int nooftaps;
    public static int tapcheck;
    // Use this for initialization
    void Start()
    {
        wordanimator = GetComponent<Animator>();
        if (anim != null)
            iconanimator = anim.GetComponent<Animator>();
        if (anim2 != null)
            graphicanimator = anim2.GetComponent<Animator>();
    }


    // Takes an xml word element and reads and sets the timing data
    public void SetupWordTiming(XmlNode wordNode)
    {
        startTime = float.Parse(wordNode.Attributes["msStart"].Value) / 1000.0f;
        endTime = float.Parse(wordNode.Attributes["msEnd"].Value) / 1000.0f;
        delayTime = endTime - startTime;
    }

    // Returns the absolute start time
    public float GetStartTime()
    {
        return startTime;
    }

    // Returns the absolute end time
    public float GetEndTime()
    {
        return endTime;
    }
    public void OnDrag()
    {
        Debug.Log("drag true-------");
        GameObject[] g=GameObject.FindGameObjectsWithTag("anim");
        foreach(GameObject go in g) {
            go.SetActive(false);
        }
        OnMouseUp();
    }
    // Mouse Down Event
    public void OnMouseDown()
    {
        Debug.Log("on mouse down00");
        clipPlay();
        
        iconanimPlay();
       Debug.Log("gururocks");
        //if(tinkerGraphic!=null)
        graphicPlay();
    }
   


    public void OnMouseUp()
    {
        // a.speed = 1 / delayTime;
        //clipPlay1();
        //      Debug.Log("on mouse up");
        //      //if(!pairedgraphic)
            clipResume();
        //if (nooftaps < 2)
        iconanimResume();
        
        //wordanimator.SetTrigger("resume");
        graphicResume();
        //Debug.Log(anim.active);

    }
   
    //public void clipResume() {
    //    StartCoroutine(clipResu());
    //}
    public void clipResume()
    {


        //if (nooftaps > 2)
        //{

        //    if (pairedTinkerText != null)
        //    {
        //        pairedTinkerText.clipPlay();
        //        pairedTinkerText.clipResume();
        //    }
        //}
        //else {
        Debug.Log("resumed word");
            wordanimator.SetTrigger("resume");
        //}
        
    }
    public void clipPlay()
    {

		//if (nooftaps < 2||check)
  //      {
  //          check = false;
            Debug.Log("entered clip play");
            AudioSource source = gameObject.GetComponent<AudioSource>();
            delayTime = 0.21f;
            wordanimator.speed = 1 / (delayTime);
            Debug.Log("source play");
            source.Play();
            wordanimator.SetTrigger("tapme");
            //Debug.Log("clip play " + pairedgraphic);
            Debug.Log("tapcounttext: " + nooftaps);
    //    }
        //else {
			
        //    //Debug.Log("else clip play");
        //    if (pairedTinkerText != null)
        //    {
        //        Debug.Log("else clip play");
        //        check = true;
        //        pairedTinkerText.clipPlay();
        //        pairedTinkerText.clipResume();
        //        //animshit.SetTrigger("crack3");

        //    }
        //}


    }
    public void iconanimPlay()
    {
        Debug.Log("icon anim");
        //if (nooftaps < 2)
        //{
        // Debug.Log("icon anim 2 ");
        if (iconanimator != null)
        {
            anim.SetActive(true);
            iconanimator.SetTrigger("tap");
        }
    //    }
    }
    public void iconanimResume()
    {
        if (iconanimator != null)
        {
            iconanimator.SetTrigger("tapup");
            anim.SetActive(false);
        }
    }
    //public void graphicPlay()
    //{

    //    StartCoroutine(graphicPla());
    //}
    public void graphicPlay()
    {
        if (anim2 != null)
            anim2.SetActive(true);
        if (graphicanimator != null)
        {
            if (nooftaps < 3)

            {
                int i = nooftaps + 1;
                graphicanimator.SetTrigger("crack"+i);
               nooftaps++;
            }
			
            else{
                graphicanimator.SetTrigger("crack3");
                nooftaps = 0;
            }
        }

        }
    void graphicResume()
    {
        //if (tinkerGraphic != null)
        //    tinkerGraphic.OnMouseUp();

    }

}
