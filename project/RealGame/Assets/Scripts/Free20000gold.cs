using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Free20000gold : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        var money = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", money + 1000);
    }

}
