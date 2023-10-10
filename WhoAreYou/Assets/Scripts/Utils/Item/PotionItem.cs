using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionItem : MonoBehaviour
{ 
    public int hp = 0;
    public int maxHp = 0;

    public void Potion()
    {
        hp = GameObject.FindWithTag("Player").GetComponent<Stat>().Hp;
        maxHp = GameObject.FindWithTag("Player").GetComponent <Stat>().MaxHp;

        if(hp < maxHp/2)
        {
            GameObject.FindWithTag("Player").GetComponent<Stat>().Hp += 3;
        }
    }
}
