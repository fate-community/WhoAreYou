using System.Collections.Generic;
using UnityEngine;
using static Datas;

public class QuestTestUI : MonoBehaviour
{
    DialogueData[] testDialogue = new DialogueData[2];
    int count = 0;

    void Start()
    {
        testDialogue[0] = transform.Find("DialogueButton").GetComponent<DialogueController>().dialogueData;
        testDialogue[1] = transform.Find("DialogueButton(NotQuest)").GetComponent<DialogueController>().dialogueData;
    }

    public void OnClickCreateQuest()
    {
        Dictionary<int, int> goalDic = new Dictionary<int, int>{ { 1000, 1 } };
        Managers.Quest.CreateNewQuest(1000 + count++, "대화하기", "대화를 하고 삽시다", null, goalDic);
    }

    public void OnClickDialogue()
    {
        Managers.Dialogue.ShowDialogue(testDialogue[0]);
    }

    public void OnClickDialogueTwo()
    {
        Managers.Dialogue.ShowDialogue(testDialogue[1]);
    }
}
