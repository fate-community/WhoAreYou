using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    private int itemCount = 0;
    public int usedCount = 0;

    public enum ItemType 
    {
        Weapon,
        Gold,
        Potion
    }

    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public int itemCounter
    { 
        set { itemCount = value; }
        get { return itemCount; }
    }

    public void ItemUse()
    {
        itemCount--;

        usedCount++;
    }
}
