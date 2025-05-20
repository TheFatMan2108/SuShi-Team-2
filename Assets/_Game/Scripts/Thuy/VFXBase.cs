using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXBase : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        OnPlay();
    }
    protected virtual void OnPlay()
    {

    }
}
