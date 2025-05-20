using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [SerializeField] int id;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ObjectsBase suShi))
        {
            if(suShi.id == id)
            {
                suShi.isTrigger = true;
                suShi.onComplete += TeleToPoint;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ObjectsBase suShi))
        {
            if (suShi.id == id)
            {
                suShi.isTrigger = false;
                suShi.onComplete -= TeleToPoint;
            }
        }
    }
    private void TeleToPoint(Transform sushi)
    {
        sushi.position = transform.position;
    }
}
