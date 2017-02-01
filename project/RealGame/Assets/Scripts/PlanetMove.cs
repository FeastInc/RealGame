 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetMove : MonoBehaviour {

    private Vector2 position;
    private double angle;
    [SerializeField]
    private float Speed;

	// Use this for initialization
	void Start ()
    {
        position = transform.position;
        angle = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        angle += 10 * 180 / Math.PI;
        var direction = new Vector2((float)(position.x * Math.Cos(angle)), (float)(position.y * Math.Sin(angle)));

        transform.position = Vector2.MoveTowards(transform.position, direction, Speed * Time.deltaTime);

        position = transform.position;
	}
}
