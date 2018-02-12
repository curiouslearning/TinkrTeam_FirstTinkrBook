using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stanza : MonoBehaviour {
    public StanzaManager stanzaManager;
    public List<TinkerText> tinkerTexts;
    // Time delay at end of stanza during autoplay
    public float endDelay;
    private TinkerText mouseDownTinkerText;
    private TinkerText mouseCurrentlyDownTinkerText;

  
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator AutoPlay(TinkerText startingTinkerText = null)
    {
        int startingTinkerTextIndex = 0;

        if (startingTinkerText != null)
        {
            startingTinkerTextIndex = tinkerTexts.IndexOf(startingTinkerText);
        }

        for (int i = startingTinkerTextIndex; i < tinkerTexts.Count; i++)
        {
            // delay according to timing data
            //animation not integrated
            //yield return new WaitForSeconds(tinkerTexts[i].GetAnimationDelay());
            TinkerText t = tinkerTexts[i];
            Animator anim = t.GetComponent<Animator>();
            anim.speed = 1 / t.delayTime;
            
            // If we aren't on last word, delay before playing next word
            if (i < tinkerTexts.Count - 1)
            {
                float pauseDelay = tinkerTexts[i + 1].GetStartTime() - tinkerTexts[i].GetEndTime();

                anim.Play("textzoomout");
                yield return new WaitForSeconds(t.delayTime/2);

                //anim.SetTrigger("tapme");
                anim.Play("textzoomin");
                yield return new WaitForSeconds(t.delayTime / 2);

                anim.speed = 1 / pauseDelay;
                anim.Play("pausedelay");
                //anim.SetTrigger("resume");
                yield return new WaitForSeconds(pauseDelay);

            }
            else // Delay before next stanza
            {
               // anim.SetTrigger("tapme");
               // anim.SetTrigger("resume");
                anim.Play("textzoomout");
                yield return new WaitForSeconds(t.delayTime / 2);

                anim.Play("textzoomin");
                yield return new WaitForSeconds(t.delayTime / 2);
                if (endDelay != 0)
                {
                    anim.speed = 1 / endDelay;
                    anim.Play("pausedelay");
                }

                yield return new WaitForSeconds(endDelay);

            }

            // Abort early?
            if (stanzaManager.CancelAutoPlay())
            {
                yield break;
            }
        }

        // Stop the coroutine
        yield break;
    }


    public void OnDrag(TinkerText tinkerText)
    {
        tinkerText.OnDrag();
        // and reassign it to currently down 
        int currentTextIndex = tinkerTexts.IndexOf(tinkerText);

        stanzaManager.RequestAutoPlay(this, tinkerTexts[currentTextIndex]);
    }

    public void OnMouseUp(TinkerText tinkerText)
    {
        // Assign this new one
        mouseDownTinkerText = tinkerText;
        // And signal the tinkerText 
        tinkerText.OnMouseUp();
    }
  
    public void OnMouseDown(TinkerText tinkerText)
    {
        // Assign this new one
        mouseDownTinkerText = tinkerText;
        // And signal the tinkerText 
        tinkerText.OnMouseDown();
    }
}
