using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;          // Slot의 부모 (Bag)
    [SerializeField]
    private Slot[] slots;                  // Bag의 하위에 등록된 Slot

    TMP_Text text;
    int itemCount = 0;


    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        // 게임이 시작되면 items에 들어있는 아이템을 인벤토리에 넣어줌
        FreshSlot();
    }

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    public void FreshSlot()
    {
        for (int i = 0; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(Item _item)
    {
        if(items.Equals(_item))
        {
            itemCount++;
            // 각각의 UI Text에 붙여서 개수 표기해야 함
        }

        if(items.Count < slots.Length)     // item들어올때마다 새슬롯에 등록됨, 같은 아이템이 들어오면 개수를 늘리고 싶음(UI로)
        {
            items.Add(_item);
            FreshSlot();
        }

        else
        {
            // print("가방이 꽉 찼어요ㅠㅠ");
            // UI로 띄울거임
        }
    }
}
