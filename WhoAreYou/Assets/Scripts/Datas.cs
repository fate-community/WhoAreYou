using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas
{
    [Serializable]
    public class DialogueData
    {
        public List<string> data;

        public DialogueData()
        {
            data = new List<string>();
        }
    }
}
