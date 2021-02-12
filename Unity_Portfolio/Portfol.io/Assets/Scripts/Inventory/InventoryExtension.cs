using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryExtension : MonoBehaviour
{
    public int space = 27;
    public Item[] slots;
    public int[] items_count;

    void Start()
    {
        //If predefined content
        if (slots.Length != 0)
        {
            Array.Resize(ref slots, space);
        }
        else
        {
            slots = new Item[space];

        }

        if (items_count.Length != 0)
        {
            Array.Resize(ref items_count, space);
        }
        else
        {
            items_count = new int[space];

        }
    }

    public void AddItem(Item item, int count, int index)
    {
        slots[index] = item;
        items_count[index] = count;
    }
    
}
