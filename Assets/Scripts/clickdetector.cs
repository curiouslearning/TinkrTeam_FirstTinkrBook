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
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag end");
        sceneManager.OnDragEnd();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);

        GameObject cl = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(cl);
        if (cl != null)
        {
            sceneManager.OnPointerClick(cl);
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        sceneManager.OnMouseDown(eventData.pointerCurrentRaycast.gameObject);
        Debug.Log("click detector on mouse down");
        Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
       // sceneManager.OnMouseDown(eventData.pointerCurrentRaycast.gameObject);
    }
   


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("pointer up");
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
