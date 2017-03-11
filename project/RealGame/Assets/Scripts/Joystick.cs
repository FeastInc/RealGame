using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    GameObject player;

	void Start ()
    {
        if (PlayerPrefs.GetInt("IsFirstRun") == 0)
        {
            PlayerPrefs.SetInt("IsFirstRun", 1);
            PlayerPrefs.SetString("Player", "Simple");
            PlayerPrefs.SetInt("Simple", 1);
        }

        player = Instantiate(Resources.Load("Prefabs/Players/" + PlayerPrefs.GetString("Player"))) as GameObject;
    }
	
	void Update ()
    {
		
	}
}
