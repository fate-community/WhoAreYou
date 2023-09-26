using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;     // Image Component ���� ��

    private Item _item;
    public Item item
    {
        get { return _item; }    // ������ item ������ �Ѱ��� �� ���
        set 
        {
            _item = value;       // item�� ������ ������ ���� _item�� ����
            
            if(_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
