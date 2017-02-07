using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundOnOff : MonoBehaviour, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField]
    private Sprite SoundOn;
    [SerializeField]
    private Sprite SoundOff;
    [SerializeField]
    private AudioSource audio;

	void Start ()
    {
        //audio = Camera.main.GetComponent<AudioListener>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var spriteName = GetComponent<SpriteRenderer>().sprite.name;

        if (spriteName == "SoundOn")
        {
            GetComponent<SpriteRenderer>().sprite = SoundOff;
            audio.volume = 0;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = SoundOn;
            audio.volume = 0.5f;
        }
    }
}
