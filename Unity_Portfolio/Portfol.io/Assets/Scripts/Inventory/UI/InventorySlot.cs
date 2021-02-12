using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public int index;
    public Image icon;
    public GameObject tmp;

    Item item;
    public bool selected = false;

    

    public void Start()
    {
        index = GetIndex();
    }

    public virtual int GetIndex()
    {
        return transform.GetSiblingIndex();
    }

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        tmp.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        tmp.SetActive(false);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void SelectItem()
    {
        selected = !selected;
        Inventory.instance.Select(index);
    }

    public void SetCount(int count)
    {
        tmp.GetComponent<TextMeshProUGUI>().SetText(count+"");
    }

}
