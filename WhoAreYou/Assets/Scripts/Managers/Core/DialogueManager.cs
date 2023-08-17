using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Datas;

public class DialogueManager
{
    public DialogueData dialogueData;
    public int currentDialogueIndex;
    public bool isShowing;

    GameObject dialogueUIObject;
    public TextMeshProUGUI dialogueUIText;
    public TextMeshProUGUI nameUIText;
    public Image dialogueIllust;

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
        nameUIText = dialogueUIObject.transform.Find("Panel/NameText").GetComponent<TextMeshProUGUI>();
        dialogueIllust = dialogueUIObject.transform.Find("Panel/Illust").GetComponent<Image>();
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
            dialogueIllust.color = new Color(dialogueIllust.color.r, dialogueIllust.color.g, dialogueIllust.color.b, 0);
            dialogueUIObject.SetActive(false);
            currentDialogueIndex = 0;
        }
    }

    public void ShowDialogue(DialogueData _dialogueData)
    {
        dialogueData = _dialogueData;
        currentDialogueIndex = 0;
        ShowDialogue();
    }
}
