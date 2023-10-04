using UnityEngine;
using static Datas;

public class DialogueController : MonoBehaviour
{
    bool isReady = false;
    public DialogueData dialogueData;

    void Start()
    {
        if (gameObject.tag == "NPC")
        {
            dialogueData = Managers.Data.LoadJsonData<DialogueData>($"Data/Dialogue/{gameObject.name}.json", true);
        }
        Managers.Input.KeyDownAction -= DialogueTrigger;
        Managers.Input.KeyDownAction += DialogueTrigger;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            isReady = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            isReady = false;
    }

    void DialogueTrigger(KeyCode key)
    {
        if (!isReady || Managers.Dialogue.isShowing)
            return;
        if (key == KeyCode.E)
            Managers.Dialogue.ShowDialogue(dialogueData);
    }
}
