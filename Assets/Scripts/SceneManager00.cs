using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager00 : SManager { 

   public override void OnMouseDown(GameObject go)
    {
		if (go.name == "egg_anim")
		{
			NextScene();
		}


    }

}
