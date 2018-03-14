using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager00 : SManager {

    public void Start()
    {
        StartCoroutine(Playloopingsound(0.49f,0.5f));
    }
    public override void OnMouseDown(GameObject go)
    {
		if (go.name == "egg_anim")
		{
			NextScene();
		}


    }

}
