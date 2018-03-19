using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager00 : SManager {
    
    public override void Start()
    {
        base.Start();
        StartCoroutine(PlayLoopingSound(0,0.49f,0.5f));
    }
    public override void OnMouseDown(GameObject go)
    {
		if (go.name == "egg_anim")
		{
            StartCoroutine(PlayNonLoopSound(1,0f, 0f));
			StartCoroutine(NextSceneCoroutine());
		}


    }
    IEnumerator NextSceneCoroutine()
    {
        yield return new WaitForSeconds(0.15f);
        NextScene();
    }
}
