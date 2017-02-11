using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerWalk : MonoBehaviour
{
    public float Speed;
    private SpriteRenderer sprite;
    private Animator animator;
    private GameObject Player;
    public bool rightDirection;
    public bool isRun;
    private float directionValue = 10f;

    private PlayerState State
    {
        get { return (PlayerState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    void Start ()
    {        
        if (PlayerPrefs.GetInt("IsFirstRun") == 0)
        {
            PlayerPrefs.SetInt("IsFirstRun", 1);
            PlayerPrefs.SetString("Player", "Player");
        }

        Player = Instantiate(Resources.Load("Prefabs/Players/" + PlayerPrefs.GetString("Player"))) as GameObject;
        sprite = Player.GetComponent<SpriteRenderer>();
        animator = Player.GetComponent<Animator>();
    }
	
	void Update ()
    {
        State = PlayerState.Idle;

        if (isRun) Walk();
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
