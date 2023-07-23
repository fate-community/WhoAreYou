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
    }
    public void OnClickDialogueTestButton1()
    {
        Managers.Dialogue.dialogueData = DialogueTestData[0];
        Managers.Dialogue.DialogueAction.Invoke();
    }
}
