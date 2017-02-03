using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour {
    [SerializeField]
    private Sprite Sprite;


	// Use this for initialization
	void Start () {
        var a = GetComponent<SpriteRenderer>();
        a.sprite = Sprite;  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
