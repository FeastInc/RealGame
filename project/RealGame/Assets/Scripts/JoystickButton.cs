using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Joystick joystick;

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
