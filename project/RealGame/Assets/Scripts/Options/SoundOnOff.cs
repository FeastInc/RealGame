using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundOnOff : MonoBehaviour, IPointerDownHandler {

	// Use this for initialization
	void Start () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        var a = GetComponentsInChildren<TextMesh>();
        if (a[1].text == "Off") a[1].text = "On";
        else a[1].text = "Off";
    }

	// Update is called once per frame
	void Update () {
		
	}
    
}
