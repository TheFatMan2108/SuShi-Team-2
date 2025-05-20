using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickObject : ObjectsBase
{
    private Vector3 oldEulerAngles;

    protected override void Awake()
    {
        base.Awake();
        oldEulerAngles = transform.localEulerAngles;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (isComplete) return;
        base.OnPointerDown(eventData);
        if(transform.eulerAngles.magnitude != 0)
        {
            transform.DOLocalRotate(Vector3.zero,0.3f,RotateMode.Fast);
        }
    }

   

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (isTrigger)
            onComplete?.Invoke(transform);
        if (isComplete) return;
        transform.DOLocalRotate(oldEulerAngles, 0.3f, RotateMode.Fast);
    }
}
