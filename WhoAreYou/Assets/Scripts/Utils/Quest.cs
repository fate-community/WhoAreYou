using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int id;
    public string title;
    public string description;
    public object reward;

    Dictionary<int, int> goalDic;      // �̺�Ʈ�� �Ҵ緮 ����� ��ųʸ�
    int remainTaskCnt;

    public Quest(int _id, string _title, string _description, object _reward, Dictionary<int, int> _goalDic)
    {
        id = _id;
        title = _title;
        description = _description;
        reward = _reward;
        goalDic = new Dictionary<int, int>(_goalDic);
        remainTaskCnt = goalDic.Keys.Count;
    }

    void Start()
    {
        Managers.Quest.DialogueEndupAction -= OnTriggerQuestEvent;
        Managers.Quest.DialogueEndupAction += OnTriggerQuestEvent;
    }

    void OnTriggerQuestEvent(int recvId)
    {
        if (goalDic.ContainsKey(recvId))
        {
            if (goalDic[recvId] > 0)
                goalDic[recvId]--;
            if (goalDic[recvId] == 0)
                remainTaskCnt--;
        }
    }
}
