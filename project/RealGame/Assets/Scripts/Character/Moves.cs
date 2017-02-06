using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moves : MonoBehaviour
{
    //[SerializeField]
    //private GameObject Player;
    Vector2 delta;
    Vector2 start = new Vector2(5f, 0);
    
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
        }

    }
    public int lengthOfLineRenderer = 2;
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.sortingOrder = 1;
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(Color.blue, Color.blue);
        lineRenderer.SetWidth(0.1F, 0.1F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);
    
        delta = new Vector2((float)Screen.width / 2, (float)Screen.height / 2);
    }

    void CreateRay()
    {
        var data = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        Debug.Log(data);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, data);
    }

    void DestroyRay()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[lengthOfLineRenderer];
        points[0] = points[1] = new Vector3(0, 0, 0);
        lineRenderer.SetPositions(points);
    }
}
