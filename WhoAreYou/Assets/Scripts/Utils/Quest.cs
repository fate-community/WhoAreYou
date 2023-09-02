using UnityEngine;
using static Define;

public class Quest : MonoBehaviour
{
    public int id;
    public string title;
    public string description;
    public QuestType type;
    public object reward;

    public int goal;

    public Quest(int _id, string _title, string _description, QuestType _type, object _reward)
    {
        id = _id;
        title = _title;
        description = _description;
        type = _type;
        reward = _reward;
    }
}
