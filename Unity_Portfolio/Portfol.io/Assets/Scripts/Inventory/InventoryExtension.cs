using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryExtension : MonoBehaviour
{
    public int space = 27;
    public Item[] slots;
    public int[] items_count;

    void Start()
    {
        slots = new Item[space];
        items_count = new int[space];
    }

    public void AddItem(Item item, int count, int index)
    {
        slots[index] = item;
        items_count[index] = count;
    }
    
}
