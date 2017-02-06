using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moves : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject Player;
    
    // Update is called once per frame
    void Update()
    {


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
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, Player.transform.position);
        lineRenderer.SetPosition(0, eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(Player.transform.position);
        Debug.Log(Player.transform.localPosition);
        Debug.Log(eventData.position);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, Player.transform.localPosition);
        lineRenderer.SetPosition(1, eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[lengthOfLineRenderer];
        points[0] = points[1] = new Vector3(0, 0, 0);
        lineRenderer.SetPositions(points);
    }
}
