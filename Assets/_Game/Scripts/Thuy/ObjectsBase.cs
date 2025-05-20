using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectsBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int id = -1;
    public Action<Transform> onComplete;
    public bool isTrigger;
    protected bool isTouch;
    protected bool isComplete;

    public virtual void OnPointerDown(PointerEventData eventData)
    {
       isTouch = true;
       transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }

    public virtual void OnMouseDrag()
    {
        if (isTouch&&!isComplete)
        {
            transform.position = GetMousePositionInScreen();
        }
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }
    protected Vector3 GetMousePositionInScreen()
    {
        Vector3 screenPoint = Input.mousePosition;
        Vector3 myMouse = Vector3.zero;

        screenPoint.z = 10f; //distance of the plane from the camera/ only use in 2D
        myMouse = Camera.main.ScreenToWorldPoint(screenPoint);
        return myMouse;
    }
    private void OnComplete(Transform transform)=>isComplete = true;
    protected virtual void Awake()
    {
        onComplete += OnComplete;
    }
}
