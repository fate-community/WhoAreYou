using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item item;
    public Image itemImage;

    [SerializeField]
    private Text text_Count;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if (item.itemCounter > 0)
            {
                item.ItemUse();
                text_Count.text = item.itemCounter.ToString();
                Debug.Log(item.itemCounter);
            }

            if (item.itemCounter == 0)
            {
                ClearSlot();
            }
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작
        if(item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중
        if(item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그 끝
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }
    }

    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        item.itemCounter = _count;
        itemImage.sprite = item.itemImage;

        text_Count.text = item.itemCounter.ToString();

        if(item == null)
        { 
            text_Count.text = "0";
        }

        SetColor(1);
    }

    public void SetSlotCount(int _count)
    {
        item.itemCounter += _count;
        text_Count.text = item.itemCounter.ToString();

        if(item.itemCounter <= 0)
        {
            ClearSlot();
        }
    }

    private void ClearSlot()
    {
        item = null;
        item.itemCounter = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
    }

    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = item.itemCounter;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.item.itemCounter);

        if(_tempItem != null)
        {
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }
}
