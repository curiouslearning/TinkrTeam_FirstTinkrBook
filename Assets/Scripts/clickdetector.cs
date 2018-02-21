using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class clickdetector : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler,
IPointerExitHandler, IPointerEnterHandler,
IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public SManager sceneManager;

    public void OnDrag(PointerEventData eventData)
    {
		GameObject go = GameObject.Find(eventData.pointerCurrentRaycast.gameObject.name);
		if (go!=null && go.tag == "graphic") {
			TinkerGraphic tinkerGraphic = go.GetComponent<TinkerGraphic> ();
			sceneManager.OnDrag (tinkerGraphic);
		}
    }

    public void OnEndDrag(PointerEventData eventData)
    {
		GameObject go = GameObject.Find(eventData.pointerCurrentRaycast.gameObject.name);
		if (go != null) {
			if (go.tag == "graphic") {
				TinkerGraphic tinkerGraphic = go.GetComponent<TinkerGraphic> ();
				sceneManager.OnDragEnd (tinkerGraphic);
			} else {
				sceneManager.OnDragEnd ();
			}
		}
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(obj);
        if (obj != null)
        {
            sceneManager.OnPointerClick(obj);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        sceneManager.OnMouseDown(eventData.pointerCurrentRaycast.gameObject);
    }
   


    public void OnPointerUp(PointerEventData eventData)
    {
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        if (go != null)
        {
            sceneManager.OnMouseUp(eventData.pointerCurrentRaycast.gameObject);
        }


    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        GameObject go = GameObject.Find(eventData.pointerCurrentRaycast.gameObject.name);
        if (go != null)
        {
            sceneManager.OnDragBegin(go);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
