using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragStages : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Transform Stages;
    private Vector3 startPos;
    public float Speed;
    bool isScrolling;
    Vector3 lastMousePos = Vector3.zero;
    Vector3 touchDelta = new Vector3(0f, 0f, 0f);

    void Start ()
    {
        Stages = transform.GetChild(0);
        startPos = transform.position;
    }

	void Update ()
    {
        //if (Input.touchCount > 0) Swipe();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    // тут, если нужно, рейкастишь по бэкграунду
        //    {
        //        isScrolling = true;
        //        lastMousePos = Input.mousePosition;
        //        touchDelta = Vector3.zero;
        //    }
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    isScrolling = false;
        //    touchDelta = Vector3.zero;
        //    lastMousePos = Vector3.zero;
        //}

        //Vector3 newMousePos = Input.mousePosition;
        //if (isScrolling)
        //{
        //    touchDelta = newMousePos - lastMousePos;
        //    lastMousePos = newMousePos;
        //}

        //Stages.position -= new Vector3(touchDelta.x, touchDelta.y, 0f);
    }

    //void Swipe()
    //{
    //    var delta = Input.GetTouch(0).deltaPosition;

    //    Debug.Log(startPos.x - 622.0f);

    //    if (Mathf.Abs(delta.x) > 0)
    //    {
    //        if ((delta.x > 0 && transform.position.x < startPos.x) ||
    //            (delta.x < 0 && transform.position.x > startPos.x - 622.0f))
    //        {
    //            var nextPosX = delta.x * delta.x * Math.Sign(delta.x);
    //            var nextPos = new Vector2(transform.position.x + nextPosX, transform.position.y);
    //            transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    //        }

    //    }
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.delta;

        if (Mathf.Abs(delta.x) > 0)
        {
            var nextPosX = delta.x * 10f;
            var nextPos = new Vector3(nextPosX, 0, 0);
            //Stages.position = Vector3.MoveTowards(Stages.position, Stages.position + nextPos, Speed * Time.deltaTime);
            Speed = delta.x;
            Stages.Translate(Speed * Time.deltaTime, 0, 0);
        }
    }
}
