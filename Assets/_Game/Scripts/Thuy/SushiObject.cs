using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SushiObject : SushiBase
{
    public int id = -1;
    public Action<Transform> onComplate;
    public bool isTrigger;
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }

    public override void OnPointerMove(PointerEventData eventData)
    {
        base.OnPointerMove(eventData);
        if(isTouch)
        {
            transform.position = GetMousePositionInScreen();
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (isTrigger)
            onComplate?.Invoke(transform);
    }
}
