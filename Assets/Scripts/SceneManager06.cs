using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager06 : SManager {


    public override void OnPairedMouseDown(TinkerText tinkerText)
    {
        int len = tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>().Length;
        for (int i = 0; i < len; i++)
        {
            tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[i].material.color = tinkerText.pairedGraphic.highlightColor;

        }
    }
    public override void OnPairedMouseUp(TinkerText tinkerText)
    {
        int len = tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>().Length;
        for (int i = 0; i < len; i++)
        {
            tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[i].material.color = tinkerText.pairedGraphic.resetColor;

        }


    }


}
