using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public int id;
    public string title;
    public string description;
    public object reward;

    Dictionary<int, int> goalDic;      // 이벤트별 할당량 저장용 딕셔너리
    int remainTaskCnt;

    public Quest(int _id, string _title, string _description, object _reward, Dictionary<int, int> _goalDic)
    {
        id = _id;
        title = _title;
        description = _description;
        reward = _reward;
        goalDic = new Dictionary<int, int>(_goalDic);
        remainTaskCnt = goalDic.Keys.Count;

        Managers.Quest.QuestPerformAction += OnTriggerQuestEvent;
    }

    void OnTriggerQuestEvent(int recvId)
    {
        if (goalDic.ContainsKey(recvId))
        {
            if (goalDic[recvId] > 0)
                goalDic[recvId]--;
            if (goalDic[recvId] == 0)
                remainTaskCnt--;
            if (remainTaskCnt == 0)
            {
                Managers.Quest.QuestPerformAction -= OnTriggerQuestEvent;
                Managers.Quest.questList.Remove(this);
                GameObject.Destroy(Managers.Quest.questUIDic[id]);
                Managers.Quest.questUIDic.Remove(id);
            }
        }
    }
}
