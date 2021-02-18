using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Gatherable
{
    public bool isUsable = false;
    public Transform destination = null;

    public override void Interact()
    {
        base.Interact();
        Teleport();
    }

    void Teleport()
    {
        if (isUsable)
        {
            player.position = destination.position + new Vector3(0,1,0);
            player.gameObject.GetComponent<PlayerController>().SetFocus(destination.gameObject.GetComponent<Teleporter>());
        }
        else
        {
            Debug.Log("Door is closed");
        }
    }
}
