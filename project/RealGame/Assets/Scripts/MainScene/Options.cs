using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Options : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject firstChild;
    [SerializeField]
    private GameObject secondChild;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (firstChild.active == false)
        {
            firstChild.SetActive(true);
            secondChild.SetActive(true);
        }
        else
        {
            firstChild.SetActive(false);
            secondChild.SetActive(false);
        }       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    void Start ()
    {

    }
	
	void Update ()
    {
		
	}
}
