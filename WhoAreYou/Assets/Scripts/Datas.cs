using System;
using System.Collections.Generic;
using UnityEngine;

public class Datas
{
    [Serializable]
    public class DialogueData
    {
        public List<DialogueDataSet> data;

        public DialogueData()
        {
            data = new List<DialogueDataSet>();
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
