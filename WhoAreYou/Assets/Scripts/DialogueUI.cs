using System.Collections;
using UnityEngine;
using static Datas;

public class DialogueUI : MonoBehaviour
{
    Coroutine letterAnimation;

    void Awake()
    {
        Managers.Dialogue.DialogueAction -= ShowDialogue;
        Managers.Dialogue.DialogueAction += ShowDialogue;
    }

    public void OnDialogueButtonClick()
    {
        if (!Managers.Dialogue.isShowing)
        {
            Managers.Dialogue.currentDialogueIndex += 1;
            Managers.Dialogue.ShowDialogue();
        }
        else
        {
            Managers.Dialogue.isShowing = false;
            StopCoroutine(letterAnimation);
            Managers.Dialogue.dialogueUIText.text = Managers.Dialogue.dialogueData.data[Managers.Dialogue.currentDialogueIndex];
        }
    }

    public void ShowDialogue()
    {
        letterAnimation = StartCoroutine(LetterAnimation());
    }

    IEnumerator LetterAnimation()   // ��ȭ ������ �� ���ھ� �����شٴ� �ǹ̿��� Animation�� ���, ĳ���� �ִϸ��̼ǰ��� ����� ����
    {
        yield return null;
        for (int i = 1; i <= Managers.Dialogue.dialogueData.data[Managers.Dialogue.currentDialogueIndex].Length; i++)
        {
            Managers.Dialogue.dialogueUIText.text = Managers.Dialogue.dialogueData.data[Managers.Dialogue.currentDialogueIndex].Substring(0, i);
            yield return new WaitForSeconds(0.015f);
        }
        Managers.Dialogue.isShowing = false;
    }
}
