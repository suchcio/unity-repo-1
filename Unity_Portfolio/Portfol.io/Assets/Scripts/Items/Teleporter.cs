using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Interactable
{
    public bool isUsable = false;
    public Transform player = null;
    public Transform destination = null;

    public override void Interact()
    {
        base.Interact();

        player = base.player;
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
