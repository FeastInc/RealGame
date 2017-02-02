using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetMove : MonoBehaviour
{

    private Vector2 position;
    private double angle;
    [SerializeField]
    private float Speed;
    private Vector2 pointRotation;
    private float radiusRotation;
    private Vector2 nextPoint;

    // Use this for initialization
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {          
        if ((Vector2)transform.position == position)
        {
            nextPoint = GetNextPoint();

        }
        else if ((Vector2)transform.position == nextPoint)
        {
            nextPoint = position;
        }     

        transform.position = Vector2.MoveTowards(transform.position, nextPoint, Speed * Time.deltaTime);
    }

    private Vector2 GetNextPoint()
    {       
        var rnd = new System.Random();
        var rndNumber = (double)rnd.Next(10, 23) / 100;
        var rightShift = rndNumber;
        var upShift = rndNumber;

        var secondRndNumber = rnd.Next(1, 5);

        if (secondRndNumber == 1)
            rightShift = -rndNumber;
        else if (secondRndNumber == 2)
            upShift = -rndNumber;
        else if (secondRndNumber == 3)
        {
            rightShift = -rndNumber;
            upShift = -rndNumber;
        }

        return new Vector2((float)(transform.position.x + rightShift), (float)(transform.position.y + upShift));
    }
}