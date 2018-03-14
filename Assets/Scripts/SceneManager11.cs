﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager11 : SManager
{
    public GameObject frog;
    // Use this for initialization
    void Start()
    {
        frog.GetComponent<SpriteRenderer>().color = GameManager.red;
    }


    public override void OnPairedMouseDown(TinkerText tinkerText)
    {
        
            tinkerText.pairedGraphic.gameObject.GetComponent<SpriteRenderer>().color = tinkerText.pairedGraphic.highlightColor;


    }
    public override void OnPairedMouseUp(TinkerText tinkerText)
    {
        frog.GetComponent<SpriteRenderer>().color = GameManager.red;

        
    }
}