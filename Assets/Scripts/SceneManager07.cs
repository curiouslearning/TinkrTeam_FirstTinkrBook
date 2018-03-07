using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager07 :  SManager {

	SpriteRenderer spriteRenderer;
	public GameObject babyD;
	// Use this for initialization
	void Start () {
		//Fetch the SpriteRenderer from the GameObject
		spriteRenderer = babyD.GetComponent<SpriteRenderer>();
		spriteRenderer.color = Color.white;
	}
	public override void OnMouseDown(GameObject go)
	{
		Color duckcolor = getDuckColor();
		//if (duckcolor!= Color.red&& duckcolor != Color.blue&& duckcolor != Color.yellow)
		if(duckcolor==Color.white)
			SingleColor(go);
		else {
			MixColor(go);
		}
	}
	public Color getDuckColor()
	{
		return spriteRenderer.color;
	}
	public void MixColor(GameObject go) {
		Color duckcolor = getDuckColor();
		if (duckcolor==Color.yellow)
		{
			if (go.name == "red")
				spriteRenderer.color = GameManager.orange;
			else if (go.name == "blue")
				spriteRenderer.color = GameManager.green;
			else if (go.name == "water")
				spriteRenderer.color = GameManager.white;
		}
		else if (duckcolor == Color.red)
		{
			if (go.name == "yellow")
				spriteRenderer.color = GameManager.orange;
			else if (go.name == "blue")
				spriteRenderer.color = GameManager.purple;
			else if (go.name == "water")
				spriteRenderer.color = GameManager.white;
		}
		else if (duckcolor == Color.blue)
		{
			if (go.name == "yellow")
				spriteRenderer.color = GameManager.green;
			else if (go.name == "red")
				spriteRenderer.color = GameManager.purple;
			else if (go.name == "water")
				spriteRenderer.color = GameManager.white;
		}
		else if (duckcolor == GameManager.orange|| duckcolor == GameManager.brown
			|| duckcolor == GameManager.purple|| duckcolor == GameManager.green)
		{

			spriteRenderer.color = GameManager.brown;
		}
		if (go.name == "water")
		{
			spriteRenderer.color = Color.white;

		}

	}

	public void SingleColor(GameObject go) {
		if (go.name == "red")
		{
			spriteRenderer.color = Color.red;

		}
		if (go.name == "blue")
		{
			spriteRenderer.color = Color.blue;

		}
		if (go.name == "yellow")
		{
			spriteRenderer.color = Color.yellow;

		}
		if (go.name == "water")
		{
			spriteRenderer.color = Color.white;

		}
	}
	

}
