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
    public float cooldown = 1;

    private void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    public override void Interact()
    {
        if (gatheringTool == null)
            return;

        if (Inventory.instance.equippedItem.GetType() == gatheringTool.GetType()) // && gathering tool level?
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
            //Create pickables - generate chance drops
            CreatePickups();
        }
        else
        {
            anim.ResetTrigger("Jump");
            anim.SetTrigger("Jump");

            Animator animPlayer = player.gameObject.GetComponentInChildren<Animator>();
            animPlayer.ResetTrigger("Gather");
            animPlayer.SetTrigger("Gather");

        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        hasInteracted = false;
    }

    int CalculateAmountOfReceivedItems(int index)
    {
        int count = 0;

        if (loot_count.Length == 0 && loot_chance.Length == 0)
        {
            return 1;
        }

        if (loot_count.Length == 0)
        {
            int result = Random.Range(0, 100);

            if (loot_chance.Length == 0)
                count++;

            if (result <= loot_chance[index])
            {
                count++;
            }

            return count;
        }
        else
        {
            for (int i = 0; i < loot_count[index]; i++)
            {
                int result = Random.Range(0, 100);

                if (loot_chance.Length == 0)
                    count++;

                if (result <= loot_chance[index])
                {
                    count++;
                }
            }

            return count;
        }

        return 0;
    }

    void CreatePickups()
    {
        int index = 0;
        Item[] pickups;
        foreach (Item item in loot)
        {
            int count = 0;
            //Roll chance for each item
            count = CalculateAmountOfReceivedItems(index);

            if (count > 0)
            {
                //Randomise position
                Vector3 position = transform.position;
                position += new Vector3(Random.Range(-10f, 10f) / 10, 0, Random.Range(-10f, 10f) / 10);
                //if < stacksize
                ObjectSpawner.instance.SpawnPrefab(loot[index], count, position);
            }

            index++;
        }
        //Scatter using animation
    }

}
