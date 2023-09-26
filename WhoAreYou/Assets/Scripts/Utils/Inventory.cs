using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField]
    private Transform slotParent;          // Slot�� �θ� (Bag)
    [SerializeField]
    private Slot[] slots;                  // Bag�� ������ ��ϵ� Slot

    TMP_Text text;
    int itemCount = 0;


    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        // ������ ���۵Ǹ� items�� ����ִ� �������� �κ��丮�� �־���
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
            // ������ UI Text�� �ٿ��� ���� ǥ���ؾ� ��
        }

        if(items.Count < slots.Length)     // item���ö����� �����Կ� ��ϵ�, ���� �������� ������ ������ �ø��� ����(UI��)
        {
            items.Add(_item);
            FreshSlot();
        }

        else
        {
            // print("������ �� á���Ф�");
            // UI�� ������
        }
    }
}
