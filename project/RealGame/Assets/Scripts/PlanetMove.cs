/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetMove : MonoBehaviour {

    private Vector2 position;
    [SerializeField]
    private float Speed;
    private Vector2 pointRotation;
    private float radiusRotation;
    private Dictionary<Vector2, Vector2> trajectory;

    private Dictionary<Vector2, Vector2> GetTrajectory(float xc, float yc, float radius)
    {
        var result = new Dictionary<Vector2, Vector2>();
        var delta = 3 - 2 * radius;
        float x = 0; var y = radius;
        float _x, _y;
        Debug.Log(x.ToString() + " y: " + y.ToString());
        while (x <= y)
        {
            _x = x; _y = y;
            if (delta < 0) delta += 4 * x + 6;
            else
            {
                delta += 4 * (x - y) + 10;
                --y;
            }
            x++;
            result[new Vector2(_x + xc, _y + yc)] = new Vector2(x + xc, y + yc);
            result[new Vector2(_x + xc, -_y + yc)] = new Vector2(x + xc, -y + yc);
            result[new Vector2(-_x + xc, -_y + yc)] = new Vector2(-x + xc, -y + yc);
            result[new Vector2(-_x + xc, _y + yc)] = new Vector2(-x + xc, y + yc);
            result[new Vector2(_y + xc, _x + yc)] = new Vector2(y + xc, x + yc);
            result[new Vector2(_y + xc, -_x + yc)] = new Vector2(y + xc, -x + yc);
            result[new Vector2(-_y + xc, -_x + yc)] = new Vector2(-y + xc, -x + yc);
            result[new Vector2(-_y + xc, _x + yc)] = new Vector2(-y + xc, x + yc);
        }
        result[new Vector2(x + xc, y + yc)] = new Vector2(xc, radius + yc);
        result[new Vector2(x + xc, -y + yc)] = new Vector2(xc, -radius + yc);
        result[new Vector2(-x + xc, -y + yc)] = new Vector2(xc, -radius + yc);
        result[new Vector2(-x + xc, y + yc)] = new Vector2(xc, radius + yc);
        result[new Vector2(y + xc, x + yc)] = new Vector2(radius + xc,yc);
        result[new Vector2(y + xc, -x + yc)] = new Vector2(radius + xc, yc);
        result[new Vector2(-y + xc, -x + yc)] = new Vector2(-radius + xc,yc);
        result[new Vector2(-y + xc, x + yc)] = new Vector2(-radius + xc, yc);
        return result;
    }

    private Dictionary<Vector2, Vector2> GetPoints()
    {
        var result = new Dictionary<Vector2, Vector2>();
        result[new Vector2(0, 0)] = new Vector2(0, 0);
        return result;
    }

    // Use this for initialization
    void Start ()
    {
        position = transform.position;
        Debug.Log(position.x.ToString() + " " + position.y.ToString());
        pointRotation = new Vector2(0, 0);
        radiusRotation = (float)Math.Sqrt((pointRotation.x - position.x) * (pointRotation.x - position.x)
            + (pointRotation.y - position.y) * (pointRotation.y - position.y));
        trajectory = GetTrajectory(pointRotation.x, pointRotation.y, radiusRotation);
        //trajectory = GetPoints();
        position = new Vector2(pointRotation.x, (float)radiusRotation + pointRotation.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (trajectory.ContainsKey(position)) Debug.Log("Yes, point is conained");
        else Debug.Log("No, point is not conained");
        transform.position = trajectory[position];
        position = trajectory[position];
	}
}*/

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

    // Use this for initialization
    void Start()
    {
        position = transform.position;
        pointRotation = new Vector2(0, 0); //точка вокруг, которой двигаются тела
        radiusRotation = (float)Math.Sqrt((pointRotation.x - position.x) * (pointRotation.x - position.x) 
            // радиус от точки поворота до центра планеты
            + (pointRotation.y - position.y) * (pointRotation.y - position.y));
        angle = (float)Math.Atan2(position.y, position.x); //сначала угол равен не 0, арктагенсу x/y
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Cos(angle) == 0 || Math.Sin(angle) == 0)
            angle += Math.PI / 180;

        var nextPoint = new Vector2((float)(radiusRotation * Math.Cos(angle)), 
            (float)(radiusRotation * Math.Sin(angle)));
        //считаю следующую точку с помощью параметрического уравнения, где параметр - это угол

        transform.position = Vector2.MoveTowards(position, nextPoint, Speed * Time.deltaTime);
        angle += Speed * Math.PI / 180; // увеличеваю угол, что-то вроде угловой скорости
        position = transform.position;
    }
}