using System;
using TMPro;
using UnityEngine;
using static Datas;

public class DialogueManager
{
    public DialogueData dialogueData;
    public int currentDialogueIndex;

    GameObject dialogueUIObject;
    TextMeshProUGUI dialogueUIText;

    public Action DialogueAction;

    public void Init()
    {
        currentDialogueIndex = 0;

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

    void ShowDialogue()
    {
        if (dialogueData.data.Count > currentDialogueIndex)
        {
            dialogueUIText.text = dialogueData.data[currentDialogueIndex];
            if (!dialogueUIObject.active)
                dialogueUIObject.SetActive(true);
        }

        else
        {
            dialogueUIObject.SetActive(false);
            currentDialogueIndex = 0;
        }
    }
}
