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

        if (usedCount > 0)
        {
            int hp = GameObject.Find("Player").GetComponent<Stat>().Hp;
            int maxHp = GameObject.Find("Player").GetComponent <Stat>().MaxHp;

            if(hp < maxHp/2)
            {
                GameObject.Find("Player").GetComponent<Stat>().Hp += 3;
            }
        }
    }
}
