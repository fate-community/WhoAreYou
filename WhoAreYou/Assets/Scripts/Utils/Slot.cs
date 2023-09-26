using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;     // Image Component 담을 곳

    private Item _item;
    public Item item
    {
        get { return _item; }    // 슬롯의 item 정보를 넘겨줄 때 사용
        set 
        {
            _item = value;       // item에 들어오는 정보의 값은 _item에 저장
            
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
