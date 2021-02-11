using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool isOpenable = false;
    public Transform player = null;

    public override void Interact()
    {
        Debug.Log("Open the doar!");
        base.Interact();

        player = base.player;
        Open();
    }

    void Open()
    {
        if (isOpenable)
        {
            player.position = transform.position;
        }
        else
        {
            Debug.Log("Door is closed");
        }
    }
}
