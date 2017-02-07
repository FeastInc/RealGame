using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moves : MonoBehaviour
{
    //[SerializeField]
    //private GameObject Player;
    [SerializeField]
    GameObject blast;
    bool fire = false;
    Vector2 delta;
    Vector2 start = new Vector2(-1f, 2f);
    Vector2 lastDirection;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            CreateRay();
        }
        else
        {
            DestroyRay();
            if (fire) Fire();
        }

    }
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.sortingOrder = 1;
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(Color.blue, Color.blue);
        lineRenderer.SetWidth(0.1F, 0.1F);
    
        delta = new Vector2((float)Screen.width / 2, (float)Screen.height / 2);
    }

    void CreateRay()
    {
        var data = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Ray2D ray = new Ray2D(start, (Vector2)data - start);
        //Debug.DrawRay(start, (Vector2)data - start, Color.red);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, 1000);
        //if (hit.collider != null)
        //{
        //    Debug.DrawRay(hit.point, hit.normal, Color.green);
        //    Debug.DrawRay(hit.point, Vector2.Reflect(ray.direction, hit.normal), Color.cyan);
        //}
        if (hit.collider != null)
        {
            lineRenderer.SetVertexCount(3);
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, hit.point);
            lineRenderer.SetPosition(2, Vector2.Reflect(ray.direction, hit.normal) + hit.point);
        }
        else
        {
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, data);
        }
        fire = true;
        lastDirection = ray.direction;
    }

    void DestroyRay()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[lineRenderer.numPositions];
        for (int i = 0; i < lineRenderer.numPositions; i++)
        {
            points[i] = new Vector3(0, 0, 0);
        }
        lineRenderer.SetPositions(points);
    }

    void Fire()
    {
        var transform = blast.transform;
        float angle;
        if (lastDirection.y < 0)
            angle = -Vector2.Angle(Vector2.right, lastDirection);
        else
            angle = Vector2.Angle(Vector2.right, lastDirection);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        blast.transform.position = blast.transform.position + blast.transform.forward * 2;
        Debug.Log(transform.forward);
        fire = false;
    }
}
