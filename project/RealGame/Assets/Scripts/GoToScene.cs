using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private string Scene;


    // Use this for initialization
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(Scene);
        Debug.Log("Button 'Back'");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
