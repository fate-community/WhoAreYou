using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager
{
    public List<Quest> questList = new List<Quest>();
    public Dictionary<int, GameObject> questUIDic = new Dictionary<int, GameObject>();

    public Action<int> DialogueEndupAction;

    GameObject questInfo;
    Transform questPanel;

    public void Init()
    {
        questInfo = Resources.Load("Prefabs/QuestInfo") as GameObject;
        questPanel = GameObject.Find("QuestCanvas").transform.Find("Panel");
    }

    public void CreateNewQuest(int questId, string title, string description, object reward, Dictionary<int, int> goalDic)
    {
        questList.Add(new Quest(questId, title, description, reward, goalDic));
        questUIDic.Add(questId, GameObject.Instantiate(questInfo, questPanel));
        questUIDic[questId].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = title;
        questUIDic[questId].transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description;
    }
}
