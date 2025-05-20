using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SushiObject : ObjectsBase
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (isComplete) return;
        base.OnPointerDown(eventData);
        transform.DOLocalRotate(new Vector3(0, 0, 4), 1).SetLoops(1, LoopType.Yoyo);
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (isTrigger&&!isComplete)
            onComplete?.Invoke(transform);
        if (isComplete) return;
        transform.DOLocalRotate(new Vector3(0, 0, 0), 1).SetLoops(1, LoopType.Yoyo);
    }

    public override void OnMouseDrag()
    {
        base.OnMouseDrag();

    }
}
