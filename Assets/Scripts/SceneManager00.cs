using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager00 : SManager { 

    public override void OnPointerClick(GameObject cl)
    {
        if (cl.name == "Duck")
        {
            NextScene();
        }

        //if (cl.name == "yellow")
        //{
        //    R1button.SetActive(true);
        //}

    }

}
