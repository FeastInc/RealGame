using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragStages : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Transform Stages;
    //private float speed = 22f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.delta.x + "   " + eventData.delta.y);
        Debug.Log("OnBeginDrag");
        if (eventData.delta.x != 0)
        {
            //var nextPos = new Vector2(eventData.delta.x, StagesTransform.position.y);
            //Stages.position = Vector2.MoveTowards(StagesTransform.position, nextPos, speed * Time.deltaTime);
            //Stages.position += new Vector3(eventData.delta.x * 100, 0, 0);
            transform.position += new Vector3(eventData.delta.x * 10, 0, 0);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
    }

    void Start ()
    {
        Stages = transform.GetChild(0);
    }

	void Update ()
    {
        //Debug.Log("Update");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }
}
