using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatherable : Interactable
{
    Animator anim;

    public Item[] loot;
    public int[] loot_count;
    public float[] loot_chance;

    public Item gatheringTool;

    public int hitPoints = 10;
    public int cooldown = 1;

    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

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
        else
        {
            Debug.Log("Jump");
            anim.ResetTrigger("Jump");
            anim.SetTrigger("Jump");
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1);
        hasInteracted = false;
    }

}
