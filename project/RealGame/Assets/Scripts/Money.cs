using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();
	}
}
