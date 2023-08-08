using UnityEngine;
using UnityEngine.UI;
using static Datas;

public class DialogueInteractTest : MonoBehaviour
{
    Button[] DialogueTestButton = new Button[2];
    DialogueData[] DialogueTestData = new DialogueData[2];
    
    void Start()
    {
        DialogueTestButton[0] = transform.Find("Test1").GetComponent<Button>();
        DialogueTestData[0] = transform.Find("Test1").GetComponent<DialogueController>().dialogueData;
        DialogueTestButton[1] = transform.Find("Test2").GetComponent<Button>();
        DialogueTestData[1] = transform.Find("Test2").GetComponent<DialogueController>().dialogueData;
    }

    public void OnClickDialogueTestButton1()
    {
        Managers.Dialogue.ShowDialogue(DialogueTestData[0]);
    }

    public void OnClickDialogueTestButton2()
    {
        Managers.Dialogue.ShowDialogue(DialogueTestData[1]);
    }
}
