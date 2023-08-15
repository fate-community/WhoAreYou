using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public GameObject Camera;

    [SerializeField]
    float _speed = 10.0f;

    public enum State
    {
        IDLE,
        RUN,
        ATTACK,
        HIT,
        DEATH
    }

    public State state;

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
        state = State.IDLE;
        animator.SetInteger("state", 0);
    }

    private void Update()
    {
        switch (state)
        {
            case State.IDLE:
                animator.SetInteger("state", 0);
                break;
            case State.RUN:
                if (animator.GetInteger("state") == 1)
                {
                    state = State.IDLE;
                }
                break;
            case State.ATTACK:
                if (animator.GetInteger("state") == 2)
                {
                    state = State.IDLE;
                }
                break;
            case State.HIT:
                break;
            case State.DEATH:
                break;

        }
    }

    void OnLeftClicked(bool clicked)
    {
        if (clicked && state != State.ATTACK)
        {
            state = State.ATTACK;
            animator.SetInteger("state", 2);
        }
    }

    void OnKeyboard(KeyCode key)
    {
        if (state == State.IDLE)
        {
            state = State.RUN;
            animator.SetInteger("state", 1);

            var offset = Camera.transform.forward;
            offset.y = 0;

            if (key == KeyCode.W)
            {
                var dir = offset;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _speed;
            }
            if (key == KeyCode.S)
            {
                var dir = -offset;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _speed;
            }
            if (key == KeyCode.D)
            {
                var dir = new Vector3(offset.z, offset.y, -offset.x);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _speed;
            }
            if (key == KeyCode.A)
            {
                var dir = new Vector3(-offset.z, offset.y, offset.x);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                transform.position += dir * Time.deltaTime * _speed;
            }
        }
    }
}
