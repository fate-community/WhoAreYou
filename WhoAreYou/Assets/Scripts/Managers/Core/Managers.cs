
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Datas;

public class Managers : MonoBehaviour
{
    // ?�합 매니?� ?�스?�스
    static Managers _managerInstance;
    static Managers ManagerInstance { get { Init(); return _managerInstance; } }

    // 갖�?지 매니?�?�의 ?�스?�스
    private static InputManager _input = new InputManager();
    private static DialogueManager _dialogue = new DialogueManager();
    private static QuestManager _quest = new QuestManager();

    public static InputManager Input { get { return _input; } }
    public static DialogueManager Dialogue { get { return _dialogue; } }
    public static QuestManager Quest { get { return _quest; } }

    void Awake()
    {
        Init();
    }

    void Update()
    {
        Input.OnUpdate();
    }

    static void Init()
    {
        if (_managerInstance == null)
        {
            GameObject go = GameObject.Find("@Manager");
            if (go == null)
            {
                go = new GameObject("@Manager");
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            _managerInstance = go.GetComponent<Managers>();
        }

        _dialogue.Init();
        Quest.Init();
    }
}
