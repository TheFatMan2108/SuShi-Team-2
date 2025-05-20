using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SushiBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    protected bool isTouch;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
       isTouch = true;
    }

    public virtual void OnPointerMove(PointerEventData eventData)
    {
       
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
    }

    protected Vector3 GetMousePositionInScreen()
    {
        Vector3 screenPoint = Input.mousePosition;
        Vector3 myMouse = Vector3.zero;

        screenPoint.z = 10f; //distance of the plane from the camera/ only use in 2D
        myMouse = Camera.main.ScreenToWorldPoint(screenPoint);
        return myMouse;
    }
}
