using System;
using System.Collections.Generic;

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
    }
}
