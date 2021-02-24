using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public int count;

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        PickUp();   // Pick it up!
    }

    // Pick up the item
    void PickUp()
    {
        bool wasPickedUp = Inventory.instance.Add(item, count);    // Add to inventory

        // If successfully picked up
        if (wasPickedUp)
            Destroy(gameObject);    // Destroy item from scene
    }

}
