using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject model = null;
    public bool isDefaultItem = false;
    public int stackSize = 100;
    public bool isPlaceable = false;
    public bool isGun = false;

    public Vector3 materializedPlacement = new Vector3(0, 0, 0);

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
 