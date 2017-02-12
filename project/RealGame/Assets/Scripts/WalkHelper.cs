using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WalkHelper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerWalk parentScript;

    public void OnPointerDown(PointerEventData eventData)
    {
        parentScript.isRun = true;

        if (gameObject.name == "LeftArrow")
            parentScript.rightDirection = false;
        else
            parentScript.rightDirection = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        parentScript.isRun = false;
    }

    void Start ()
    {
        parentScript = transform.parent.gameObject.GetComponent<PlayerWalk>();
	}
}
