using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Transform topTr;
    List<ObjectsBase> objects = new List<ObjectsBase>();

    public void AddObjectBase(ObjectsBase obj)=> objects.Add(obj);
    public void RemoveObjectBase(ObjectsBase obj)=>objects.Remove(obj);

    public bool OnComplete()
    {
        foreach (ObjectsBase item in objects)
        {
            if (!item.GetIsComplete())
            {
                return false;
            }
        }
        return true;
    }
    public Transform GetTopTr()=>topTr;
}
