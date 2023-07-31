using System;
using System.Collections;
using TMPro;
using UnityEngine;
using static Datas;

public class DialogueManager
{
    public DialogueData dialogueData;
    public int currentDialogueIndex;
    public bool isShowing;

    GameObject dialogueUIObject;
    public TextMeshProUGUI dialogueUIText;

    public Action DialogueAction;

    public void Init()
    {
        currentDialogueIndex = 0;
        isShowing = false;

        dialogueUIObject = GameObject.Find("DialogueCanvas");
        if (dialogueUIObject == null)
        {
            dialogueUIObject = GameObject.Instantiate(Resources.Load("Prefabs/DialogueCanvas") as GameObject);
        }
        dialogueUIText = dialogueUIObject.transform.Find("Panel/DialogueText").GetComponent<TextMeshProUGUI>();
        dialogueUIObject.SetActive(false);

        DialogueAction -= ShowDialogue;
        DialogueAction += ShowDialogue;
    }

    public void ShowDialogue()
    {
        if (dialogueData.data.Count > currentDialogueIndex)
        {
            if (!dialogueUIObject.active)
                dialogueUIObject.SetActive(true);
            if (!isShowing)
            {
                isShowing = true;
                DialogueAction.Invoke();
            }
        }

        else
        {
            dialogueUIObject.SetActive(false);
            currentDialogueIndex = 0;
        }
    }
}
