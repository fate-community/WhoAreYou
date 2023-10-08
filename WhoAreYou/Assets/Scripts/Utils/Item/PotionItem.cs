using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionItem : Item
{
    public PotionItem(Item item){ }
    
    public new void ItemUse()
    {
        base.ItemUse();
<<<<<<< HEAD
=======
        Debug.Log("used: " + usedCount);
>>>>>>> 196b17c5de13b52e2c0332ba153400f9a6481e90

        if (usedCount > 0)
        {
            int hp = GameObject.Find("Player").GetComponent<Stat>().Hp;
            int maxHp = GameObject.Find("Player").GetComponent <Stat>().MaxHp;

            if(hp < maxHp/2)
            {
                GameObject.Find("Player").GetComponent<Stat>().Hp += 3;
            }
<<<<<<< HEAD
=======

            Debug.Log("hp: " + GameObject.Find("Player").GetComponent<Stat>().Hp);
>>>>>>> 196b17c5de13b52e2c0332ba153400f9a6481e90
        }
    }
}
