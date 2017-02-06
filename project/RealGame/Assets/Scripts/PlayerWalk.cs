using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerWalk : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float Speed;
    private SpriteRenderer sprite;
    private Animator animator;
    [SerializeField]
    private GameObject Player;
    public bool rightDirection;
    private bool isRun;
    private float directionValue = 10f;

    private PlayerState State
    {
        get { return (PlayerState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    void Start ()
    {
        sprite = Player.GetComponent<SpriteRenderer>();
        animator = Player.GetComponent<Animator>();
	}
	
	void Update ()
    {       
        State = PlayerState.Idle;

        if (isRun) Walk();
    }

    //void Walk()
    //{       
    //    Vector3 direction = new Vector3(Input.GetTouch(0).position.x, 0, 0);

    //    if (Input.GetTouch(0).position.x > Screen.width / 2)
    //    {
    //        Player.transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, Speed * Time.deltaTime);
    //        sprite.flipX = false;
    //    }
    //    else
    //    {
    //        Player.transform.position = Vector2.MoveTowards(transform.position, transform.position - direction, Speed * Time.deltaTime);
    //        sprite.flipX = true;
    //    }

    //    State = PlayerState.Walk;
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
        isRun = true;       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRun = false;
    }

    void Walk()
    {     
        Vector3 direction = new Vector3(directionValue, 0, 0);

        if (rightDirection)
        {
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, Player.transform.position + direction, Speed * Time.deltaTime);
            sprite.flipX = false;
        }
        else
        {
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, Player.transform.position - direction, Speed * Time.deltaTime);
            sprite.flipX = true;
        }

        State = PlayerState.Walk;
    }
}

public enum PlayerState
{
    Idle,
    Walk
}
