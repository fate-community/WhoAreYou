using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected int _maxHp;
    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected int _defense;


    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }


    // Start is called before the first frame update
    void Start()
    {
        _hp = 100;
        _maxHp = 100;
        _attack = 10;
        _defense = 5;
    }

    public void OnAttacked(Stat stat)
    {
        int damage = Mathf.Max(0, stat.Attack - Defense);
        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
            OnDead(stat);
        }
    }

    public void OnDead(Stat stat)
    {
        //Application.Quit();

        // UI 구현되면 창 띄워서 게임 종료 / 재시작 등 선택할 수 있게?..
    }
}
