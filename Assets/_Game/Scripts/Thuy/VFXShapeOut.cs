using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXShapeOut : VFXBase
{
    protected override void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.DOScale(new Vector3(1,20,0), 0.2f);
        }
        base.OnEnable();
    }

    protected override void OnPlay()
    {
        base.OnPlay();
        var sequence = DOTween.Sequence();

        for (int i = 0; i < transform.childCount; i++)
        {
            sequence.Append(transform.GetChild(i).transform.DOScale(Vector3.zero,0.2f));
        }
    }
}
