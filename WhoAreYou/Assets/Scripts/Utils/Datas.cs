using System;
using System.Collections.Generic;
using UnityEngine;

public class Datas
{
    [Serializable]
    public class DialogueData
    {
        public List<DialogueDataSet> data;
        public int dialogueId;

        public DialogueData(int _dialogueId)
        {
            data = new List<DialogueDataSet>();
            dialogueId = _dialogueId;
        }
    }

    [Serializable]
    public class DialogueDataSet
    {
        public string dialogue;
        public string name;
        public Sprite illust;
    }
}
