using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum ItemType 
    {
        Weapon,
        Gold,
        Potion
    }

    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
}
