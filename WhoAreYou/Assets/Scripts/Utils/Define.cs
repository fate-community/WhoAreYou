using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum State
    {
        IDLE,
        MOVE,
        ATTACK,
        HIT,
        DIE
    }

    public enum QuestType
    {
        Dialog,
        Hunt,
        Collect
    }
}
