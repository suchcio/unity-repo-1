using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    // Start is called before the first frame update
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    // Update is called once per frame
    void PickUp()
    {
        Inventory.instance.Add(base.item,  1);
        Destroy(gameObject);
    }
}
