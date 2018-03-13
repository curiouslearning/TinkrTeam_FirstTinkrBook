using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager05 : SManager
{

    // Use this for initialization
    void Start()
    {

    }
    public override void OnPairedMouseDown(TinkerText tinkerText)
    {
        tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[0].material.color = tinkerText.pairedGraphic.highlightColor;
        tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[1].material.color = tinkerText.pairedGraphic.highlightColor;
        tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[2].material.color = tinkerText.pairedGraphic.highlightColor;
    }
    public override void OnPairedMouseUp(TinkerText tinkerText)
    {
        tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[0].material.color = tinkerText.pairedGraphic.resetColor;

        tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[1].material.color = tinkerText.pairedGraphic.resetColor;

        tinkerText.pairedGraphic.gameObject.GetComponentsInChildren<Renderer>()[2].material.color = tinkerText.pairedGraphic.resetColor;


    }
  




}
