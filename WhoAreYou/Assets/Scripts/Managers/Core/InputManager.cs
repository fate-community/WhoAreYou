using System;
using UnityEngine;

public class InputManager
{
    public Action<KeyCode> KeyAction = null;

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
    }
}
