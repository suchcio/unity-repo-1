﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public InventoryExtension ext;
    bool isOpen = false; //Istnienie tego boli

    // Start is called before the first frame update
    public override void Interact()
    {
        Debug.Log("Chest!");
        base.Interact();
        Open();
    }

    void Update()
    {
        base.Update();
        //Debug.Log(base.isFocus + " " + isOpen);
        if (!base.isFocus && isOpen)
            Close();
    }

    // Update is called once per frame
    void Open()
    {
        if (isOpen)
        {
            return;
        }
        Inventory.instance.ConnectExtension(ext);
        Inventory.instance.OpenInventory();
        InventoryUI.instance.Show();
        isOpen = true;
    }

    void Close()
    {
        Debug.Log("Closing...");
        //Inventory.instance.ConnectExtension(null);
        InventoryUI.instance.Hide();
        isOpen = false;
    }
}
