using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public void OnDialogueButtonClick()
    {
        Managers.Dialogue.currentDialogueIndex += 1;
        Managers.Dialogue.DialogueAction.Invoke();
    }
}
