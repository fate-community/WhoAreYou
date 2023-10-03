using System;
using UnityEngine;

public class InputManager
{
    public Action<KeyCode> KeyAction = null;
    public Action<KeyCode> KeyDownAction = null;
    public Action<float, float> DragAction = null;
    public Action<bool> LeftClickAction = null;
    public Action<bool> RightClickAction = null;

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

            if (Input.GetKey(KeyCode.LeftShift))
            {
                KeyAction.Invoke(KeyCode.LeftShift);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                KeyAction.Invoke(KeyCode.Space);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                KeyAction.Invoke(KeyCode.I);
            }
        }

        if (KeyDownAction != null)
        {
            if (Input.GetKeyDown(KeyCode.F1))       // ����Ʈ ����Ʈ�� �ҷ��� �� ���
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

        if (RightClickAction != null)
        {
            RightClickAction.Invoke(Input.GetMouseButtonDown(0));
        }
    }
}
