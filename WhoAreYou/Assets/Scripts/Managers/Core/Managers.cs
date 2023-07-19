using UnityEngine;

public class Managers : MonoBehaviour
{
    // ���� �Ŵ��� �ν��Ͻ�
    static Managers _managerInstance;
    static Managers ManagerInstance { get { Init(); return _managerInstance; } }

    #region Content
    static GameManager _game;
    static GameManager game { get { return _game; } }
    #endregion

    // ������ �Ŵ������� �ν��Ͻ�
    private static InputManager _input = new InputManager();
    private static DialogueManager _dialogue = new DialogueManager();

    public static InputManager Input { get { return _input; } }
    public static DialogueManager Dialogue { get { return _dialogue; } }


    static SoundManager _sound;
    static SoundManager sound { get { return _sound; } }

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
    }
}
