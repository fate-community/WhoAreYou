using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager
{
    public List<Quest> questList = new List<Quest>();
    public Dictionary<int, GameObject> questInfoUIDic = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> questPreviewUIDic = new Dictionary<int, GameObject>();

    public Action<int> QuestPerformAction;

    GameObject questListPanel;
    GameObject questInfo;
    GameObject questInfoPreview;
    Transform questInfoPoint;
    Transform questPreviewPoint;

    public void Init()
    {
        questListPanel = GameObject.Find("BaseCanvas").transform.Find("QuestListPanel").gameObject;
        questInfo = Resources.Load("Prefabs/QuestInfo") as GameObject;
        questInfoPreview = Resources.Load("Prefabs/QuestInfoPreview") as GameObject;
        questInfoPoint = GameObject.Find("BaseCanvas").transform.Find("QuestListPanel/QuestListScrollView/Viewport/Quests");
        questPreviewPoint = GameObject.Find("BaseCanvas").transform.Find("QuestPreviewScrollView/Viewport/QuestPreviews");
        questListPanel.SetActive(false);

        Managers.Input.KeyDownAction -= ToggleQuestList;
        Managers.Input.KeyDownAction += ToggleQuestList;
    }

    public void CreateNewQuest(int questId, string title, string description, object reward, Dictionary<int, int> goalDic)
    {
        questList.Add(new Quest(questId, title, description, reward, goalDic));
        questInfoUIDic.Add(questId, GameObject.Instantiate(questInfo, questInfoPoint));
        questInfoUIDic[questId].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = title;
        questInfoUIDic[questId].transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description;
        questPreviewUIDic.Add(questId, GameObject.Instantiate(questInfoPreview, questPreviewPoint));
        questPreviewUIDic[questId].transform.Find("Name").GetComponent<TextMeshProUGUI>().text = title;
        questPreviewUIDic[questId].transform.Find("Description").GetComponent<TextMeshProUGUI>().text = description;
    }

    void ToggleQuestList(KeyCode key)
    {
        if (key == KeyCode.F1)
        {
            questListPanel.SetActive(!questListPanel.activeSelf);
        }
    }
}
