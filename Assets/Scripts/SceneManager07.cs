using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager07 : SManager
{
    //waterdrops
    public GameObject fallingWater;
    public GameObject fallingRed;
    public GameObject fallingYellow;
    public GameObject fallingBlue;

    //leaves
    public GameObject waterLeaf;
    public GameObject redLeaf;
    public GameObject blueLeaf;
    public GameObject yellowLeaf;
    //babyd components
    public GameObject babyD;
    public GameObject water;
    public GameObject movingArms;
    //public GameObject[] bubbles;
    public GameObject bubble1;
    public GameObject bubble2;
    public GameObject bubble3;
    public GameObject bubble4;
    public GameObject bubble5;
    public GameObject bubble6;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRendererWater;
    private SpriteRenderer spriteRendererMovingArms;
    private SpriteRenderer bubbleSprite1;
    private SpriteRenderer bubbleSprite2;
    private SpriteRenderer bubbleSprite3;
    private SpriteRenderer bubbleSprite4;
    private SpriteRenderer bubbleSprite5;
    private SpriteRenderer bubbleSprite6;

    // Use this for initialization
	public override void Start() {
		base.Start ();
        ChangeColor(GameManager.white);
        //Fetch the SpriteRenderer from the GameObject

        spriteRenderer = babyD.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        spriteRendererWater = water.GetComponent<SpriteRenderer>();
  
        bubbleSprite1 = bubble1.GetComponent<SpriteRenderer>();
        bubbleSprite2 = bubble2.GetComponent<SpriteRenderer>();
        bubbleSprite3 = bubble3.GetComponent<SpriteRenderer>();
        bubbleSprite4 = bubble4.GetComponent<SpriteRenderer>();
        bubbleSprite5 = bubble5.GetComponent<SpriteRenderer>();
        bubbleSprite6 = bubble6.GetComponent<SpriteRenderer>();

        spriteRendererMovingArms = movingArms.GetComponent<SpriteRenderer>();
    }
    public override void OnMouseDown(GameObject go)
    {
        base.OnMouseDown(go);
        Color duckcolor = getDuckColor();
        if (duckcolor == Color.white)
            SingleColor(go);
        else
        {
            MixColor(go);
        }
    }

    public override void OnMouseDown(TinkerGraphic tinkerGraphic)
    {
        if(getDuckColor()==Color.white)
            base.OnMouseDown(tinkerGraphic);
    }

    public void PlayAudioOfLeafs(GameObject go)
    {
        Debug.Log("------"+go.name);
        if (go.name=="water_leaf")
        {
            Debug.Log("------" + go.name);
            StartCoroutine(PlayNonLoopSound(0));
        }
        else if(go.name =="red_leaf" || go.name =="blue_leaf" || go.name =="yellow_leaf")
        {

            StartCoroutine(PlayNonLoopSound(1));
        }
    }


    public Color getDuckColor()
    {
        return spriteRenderer.color;
    }
    public void ChangeColor(Color color)
    {

        StartCoroutine(WaitTime(color));
    }
    IEnumerator WaitTime(Color color)
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = color;
        spriteRendererWater.color = color;
        spriteRendererMovingArms.color = color;
        bubbleSprite1.color = color;
        bubbleSprite2.color = color;
        bubbleSprite3.color = color;
        bubbleSprite4.color = color;
        bubbleSprite5.color = color;
        bubbleSprite6.color = color;
        GameManager.duckColor = color;

    }
    public void MixColor(GameObject go)
    {
        Debug.Log("mixColor");
        Color duckcolor = getDuckColor();
        if (go.name == "water_leaf")
        {
            waterLeaf.GetComponent<Animator>().SetTrigger("start");
            fallingWater.GetComponent<Animator>().SetTrigger("start");
            ChangeColor(GameManager.white);
            StartCoroutine(PlayNonLoopSound(2));//white

        }
        else if (duckcolor == GameManager.orange || duckcolor == GameManager.brown
            || duckcolor == GameManager.purple || duckcolor == GameManager.green)
        {
            Debug.Log("entered");
            if (go.name == "red_leaf")
            {
                redLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingRed.GetComponent<Animator>().SetTrigger("start");

            }
            else if (go.name == "blue_leaf")
            {
                blueLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingBlue.GetComponent<Animator>().SetTrigger("start");

            }
            else if (go.name == "yellow_leaf")
            {
                yellowLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingYellow.GetComponent<Animator>().SetTrigger("start");


            }
            else if (go.name == "water_leaf")
            {
                waterLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingWater.GetComponent<Animator>().SetTrigger("start");

            }
            ChangeColor(GameManager.brown);
            StartCoroutine(PlayNonLoopSound(3));
        }

        else if (duckcolor == GameManager.yellow)
        {
            if (go.name == "red_leaf")
            {
                redLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingRed.GetComponent<Animator>().SetTrigger("start");

                ChangeColor(GameManager.orange);
                StartCoroutine(PlayNonLoopSound(4));

            }
            else if (go.name == "blue_leaf")
            {
                blueLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingBlue.GetComponent<Animator>().SetTrigger("start");

                ChangeColor(GameManager.green);
                StartCoroutine(PlayNonLoopSound(5));

            }
            else
            {
                SingleColor(go);
            }

        }
        else if (duckcolor == GameManager.red)
        {
            if (go.name == "yellow_leaf")
            {
                yellowLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingYellow.GetComponent<Animator>().SetTrigger("start");
                ChangeColor(GameManager.orange);
                StartCoroutine(PlayNonLoopSound(4));
            }
            else if (go.name == "blue_leaf")
            {
                blueLeaf.GetComponent<Animator>().SetTrigger("start");
                fallingBlue.GetComponent<Animator>().SetTrigger("start");
                ChangeColor(GameManager.purple);
                StartCoroutine(PlayNonLoopSound(6));
            }
            else
            {
                SingleColor(go);
            }

        }
        else if (duckcolor == GameManager.blue)
        {
            if (go.name == "yellow_leaf")
            {
                fallingYellow.GetComponent<Animator>().SetTrigger("start");
                yellowLeaf.GetComponent<Animator>().SetTrigger("start");
                ChangeColor(GameManager.green);
                StartCoroutine(PlayNonLoopSound(5));
            }
            else if (go.name == "red_leaf")
            {
                fallingRed.GetComponent<Animator>().SetTrigger("start");
                redLeaf.GetComponent<Animator>().SetTrigger("start");
                ChangeColor(GameManager.purple);
                StartCoroutine(PlayNonLoopSound(6));
            }
            else
            {
                SingleColor(go);
            }

        }



    }


    public void SingleColor(GameObject go)
    {
        Debug.Log("singleColor");
        if (go.name == "red_leaf")
        {
            redLeaf.GetComponent<Animator>().SetTrigger("start");
            fallingRed.GetComponent<Animator>().SetTrigger("start");

            ChangeColor(GameManager.red);
            StartCoroutine(PlayNonLoopSound(7));
        }
        if (go.name == "blue_leaf")
        {
            fallingBlue.GetComponent<Animator>().SetTrigger("start");
            blueLeaf.GetComponent<Animator>().SetTrigger("start");
            ChangeColor(GameManager.blue);
            StartCoroutine(PlayNonLoopSound(8));
        }
        if (go.name == "yellow_leaf")
        {
            fallingYellow.GetComponent<Animator>().SetTrigger("start");
            yellowLeaf.GetComponent<Animator>().SetTrigger("start");
            ChangeColor(GameManager.yellow);
            StartCoroutine(PlayNonLoopSound(9));

        }
        if (go.name == "water_leaf")
        {
            fallingWater.GetComponent<Animator>().SetTrigger("start");
            waterLeaf.GetComponent<Animator>().SetTrigger("start");
            ChangeColor(GameManager.white);
            StartCoroutine(PlayNonLoopSound(2));
        }
    }


}
