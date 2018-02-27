using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager01 : SManager {
    
	public GameObject graphicEgg;
	private int noOfTaps;

	void Start(){
		noOfTaps = 0;
	}

	public override void OnMouseDown(GameObject go)
    {
        if (go.tag == "text")
        {
            stanzaManager.OnMouseDown(go.GetComponent<TinkerText>());
            if (go.name == "tap") {
				if (noOfTaps < 3) {
					noOfTaps++;
					graphicEgg.GetComponent<Animator> ().SetTrigger ("crack"+noOfTaps);
				} else {
					graphicEgg.GetComponent<Animator> ().SetTrigger ("crack3");
					noOfTaps = 0;
				}
			}
		}
        else if (go.tag == "graphic")
        {
            Debug.Log("Hell");
            if (go.name == "eggcrack")
            {
                if (noOfTaps < 2)
                {
                    noOfTaps++;
                    go.GetComponent<TinkerGraphic>().pairedtext1.clipPlay();
                    graphicEgg.GetComponent<Animator>().SetTrigger("crack" + noOfTaps);
                }
                else
                {
                    graphicEgg.GetComponent<Animator>().SetTrigger("crack3");

                    go.GetComponent<TinkerGraphic>().pairedtext2.clipPlay();
                    noOfTaps = 0;
                }
            }
        }

    }

    public override void OnMouseUp(GameObject go)
    {
        if (go.tag == "text")
        {
            stanzaManager.OnMouseUp(go.GetComponent<TinkerText>());
            
        }
        else if (go.tag == "graphic")
        {
            if (go.name == "eggcrack")
            {
                if (noOfTaps < 3)
                {
                    if (noOfTaps == 0)
                    {
                        go.GetComponent<TinkerGraphic>().pairedtext2.clipResume();
                    }
                    go.GetComponent<TinkerGraphic>().pairedtext1.clipResume();
                }
                else
                {
                    go.GetComponent<TinkerGraphic>().pairedtext1.clipResume();
                    noOfTaps = 0;
                }
            }
        }

    }

}
