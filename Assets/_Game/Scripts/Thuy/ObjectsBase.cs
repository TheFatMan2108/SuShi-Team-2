using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ObjectsBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int id = -1;
    public Action<Transform> onComplete;
    public bool isTrigger;
    protected bool isTouch;
    protected bool isComplete;
    private SpriteRenderer sprite;
    private Collider2D collider;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (isComplete) return;
        isTouch = true;
       transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        sprite.sortingOrder += 1;
        Audio.Instance.PlaySFX("Bubble");
    }
    private void OnEnable()
    {
        GameManager.Ins.AddObjectBase(this);
    }
    private void OnDisable()
    {
        GameManager.Ins.RemoveObjectBase(this);
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
        if(isComplete) return;
        isTouch = false;
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        sprite.sortingOrder -= 1;
    }
    protected Vector3 GetMousePositionInScreen()
    {
        Vector3 screenPoint = Input.mousePosition;
        Vector3 myMouse = Vector3.zero;

        screenPoint.z = 10f; //distance of the plane from the camera/ only use in 2D
        myMouse = Camera.main.ScreenToWorldPoint(screenPoint);
        return myMouse;
    }
    private void OnComplete(Transform transform)
    {
        isComplete = true;
        transform.DOScale((transform.localScale - new Vector3(0.01f, 0.01f, 0.1f)),1);
        Audio.Instance.PlaySFX("Complete");
        collider.enabled = false;
        if (GameManager.Ins.OnComplete())
        {
            // event win
            Debug.Log("Win");
            GameManager.Ins.GetTopTr().DOMove(new Vector3(0, 1.6f, 0), 1).SetEase(Ease.Linear).OnComplete(() =>
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex
                //
            });
        }
    }
    protected virtual void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        onComplete += OnComplete;
    }
    public bool GetIsComplete()=>isComplete;
}
