using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
{

    private GameObject parent;

    public void OnPointerClick(PointerEventData eventData)
    {
        var spriteName = GetComponent<SpriteRenderer>().name;

        Debug.Log(spriteName);

        if (spriteName == "Current")
        {

        }
        else if (spriteName == "Bought")
        {
            PlayerPrefs.SetString("Player", gameObject.name);
            UpdateButtons();
        }
        else
        {            
            var money = PlayerPrefs.GetInt("Money");
            var price = 1;
            var childCount = parent.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                var child = parent.transform.GetChild(i);
                if (child.name == "Price")
                {
                    price = int.Parse(child.GetComponent<Text>().text);
                    break;
                }
            }

            if (price <= money)
            {
                PlayerPrefs.SetInt(parent.name, 1);
                PlayerPrefs.SetString("Player", parent.name);
                PlayerPrefs.SetInt("Money", money - price);
                UpdateButtons();
            }
            else
            {

            }                                 
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("spriteName");
    }

    void Start ()
    {
        parent = transform.parent.gameObject;

        UpdateButtons();
	}
	
	void Update ()
    {
		
	}

    void UpdateButtons()
    {        
        if (parent.name == PlayerPrefs.GetString("Player"))
        {
            var sprite = Resources.Load("BuyButtons/Current", typeof(Sprite)) as Sprite;
            //var sprite = spriteObj.GetComponent<SpriteRenderer>().sprite;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else if (PlayerPrefs.GetInt(parent.name) == 0)
        {
            var sprite = Resources.Load("BuyButtons/NotBought", typeof(Sprite)) as Sprite;
            //var sprite = spriteObj.GetComponent<SpriteRenderer>().sprite;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        else
        {
            var sprite = Resources.Load("BuyButtons/Bought", typeof(Sprite)) as Sprite;
            //var sprite = spriteObj.GetComponent<SpriteRenderer>().sprite;
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
