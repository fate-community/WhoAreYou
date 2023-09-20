using System;
using UnityEngine;

public class InputManager
{
    public Action<KeyCode> KeyAction = null;
    public Action<KeyCode> KeyDownAction = null;
    public Action<float, float> DragAction = null;
    public Action<bool> LeftClickAction = null;

    private float xmove = 0;
    private float ymove = 0;

    public void OnUpdate()
    {
        if (KeyAction != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                KeyAction.Invoke(KeyCode.W);
            }

            if (Input.GetKey(KeyCode.A))
            {
                KeyAction.Invoke(KeyCode.A);
            }

            if (Input.GetKey(KeyCode.S))
            {
                KeyAction.Invoke(KeyCode.S);
            }

            if (Input.GetKey(KeyCode.D))
            {
                KeyAction.Invoke(KeyCode.D);
            }
        }

        if (KeyDownAction != null)
        {
            if (Input.GetKeyDown(KeyCode.F1))       // 퀘스트 리스트를 불러올 때 사용
            {
                KeyDownAction.Invoke(KeyCode.F1);
            }
        }

        if (DragAction != null)
        {
            xmove += Input.GetAxis("Mouse X");
            ymove -= Input.GetAxis("Mouse Y");

            DragAction.Invoke(xmove, ymove);
        }

        if (LeftClickAction != null)
        {
            LeftClickAction.Invoke(Input.GetMouseButtonDown(0));
        }
    }
}
