using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public enum ItemType 
    {
        Potion
    }

    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
}
