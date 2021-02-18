using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatherable : Interactable
{
    [SerializeField]
    public Item[] loot;
    public int[] loot_count;
    public Item gatheringTool;

    public int hitPoints = 10;
    public int cooldown = 1;

    public override void Interact()
    {
        if (Inventory.instance.equippedItem == gatheringTool && gatheringTool != null)
        {
            Break();
            return;
        }
        else
        {

        }

    }

    public void Break()
    {
        StartCoroutine("Cooldown");
        hitPoints--;
        Debug.Log("Hit!");
        if (hitPoints <= 0) {
            Debug.Log("Successfully destroyed object!");
            Destroy(transform.gameObject);
            //Create pickables
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        hasInteracted = false;
    }

}
