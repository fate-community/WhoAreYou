using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public GameObject Camera;

    [SerializeField]
    float _walkSpeed = 5.0f;
    [SerializeField]
    float _runSpeed = 10.0f;
    bool _run = false;
    bool _attack = true;

    public enum State
    {
        IDLE,
        WALK,
        RUN,
        ATTACK,
        HIT,
        DEATH
    }

    public State playerState;

    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.LeftClickAction -= OnLeftClicked;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.LeftClickAction += OnLeftClicked;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerState = State.IDLE;
        animator.SetInteger("state", 0);
    }

    private void Update()
    {
        switch (playerState)
        {
            case State.IDLE:
                break;
            case State.RUN:
                if (!_run)
                {
                    changeState(State.IDLE);
                }
                break;
            case State.ATTACK:
                if (!_attack)
                {
                    changeState(State.IDLE);
                }
                break;
            case State.HIT:
                break;
            case State.DEATH:
                break;

        }
        _run = false;
    }

    protected void changeState(State state)
    {
        switch (state)
        {
            case State.IDLE:
                playerState = State.IDLE;
                animator.SetInteger("state", 0);
                break;
            case State.WALK:
                playerState = State.WALK;
                animator.SetInteger("state", 1);
                break;
            case State.RUN:
                playerState = State.RUN;
                animator.SetInteger("state", 2);
                break;
            case State.ATTACK:
                playerState = State.ATTACK;
                animator.SetInteger("state", 3);
                _attack = true;
                Invoke("attackCounter", 1.45f);
                break;
            case State.DEATH:
                playerState = State.DEATH;
                animator.SetInteger("state", 4);
                break;
            case State.HIT:
                playerState = State.HIT;
                animator.SetInteger("state", 5);
                break;
        }
    }

    protected void attackCounter()
    {
        _attack = false;
    }

    void OnLeftClicked(bool clicked)
    {
        if (clicked && playerState != State.ATTACK)
        {
            changeState(State.ATTACK);
        }
    }

    void OnKeyboard(KeyCode key)
    {
        if (playerState == State.IDLE && playerState != State.ATTACK)
        {
            changeState(State.RUN);
        }
        if (playerState == State.RUN)
        {
            var offset = Camera.transform.forward;
            offset.y = 0;

            if (key == KeyCode.W)
            {
                _run = true;
                var dir = offset;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _runSpeed;
            }
            if (key == KeyCode.S)
            {
                _run = true;
                var dir = -offset;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _runSpeed;
            }
            if (key == KeyCode.D)
            {
                _run = true;
                var dir = new Vector3(offset.z, offset.y, -offset.x);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _runSpeed;
            }
            if (key == KeyCode.A)
            {
                _run = true;
                var dir = new Vector3(-offset.z, offset.y, offset.x);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _runSpeed;
            }
        }
    }
}
