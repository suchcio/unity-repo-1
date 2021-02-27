using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlot : InventorySlot
{
    public int space = 20;

    void Start()
    {
        base.Start();
    }

    public override int GetIndex()
    {
        return transform.GetSiblingIndex()+space;
    }

}
