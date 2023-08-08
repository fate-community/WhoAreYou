using System.Collections;
using System.Collections.Generic;
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

            Vector3 cameraPos = new Vector3(Camera.transform.position.x, 0, Camera.transform.position.z);

            if (key == KeyCode.W)
            {
                Vector3 dir = new Vector3(-cameraPos.x, 0, -cameraPos.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                // transform.position += Vector3.forward * Time.deltaTime * _speed;
            }
            if (key == KeyCode.S)
            {
                Vector3 dir = new Vector3(cameraPos.x, 0, cameraPos.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                // transform.position += Vector3.back * Time.deltaTime * _speed;
            }
            if (key == KeyCode.A)
            {
                Vector3 dir = new Vector3(-cameraPos.x, 0, -cameraPos.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                // transform.position += Vector3.left * Time.deltaTime * _speed;
            }
            if (key == KeyCode.D)
            {
                Vector3 dir = new Vector3(-cameraPos.x, 0, -cameraPos.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.2f);
                // transform.position += Vector3.right * Time.deltaTime * _speed;
            }
        }
    }
}
