using System.Collections;
using System.Text;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public InventoryExtension extension;
    public InventoryUI inventoryUI;

    public int space = 20;
    public Item[] slots;
    public int[] items_count;
    public int space_count;
    public int selectedIndex = -1;

    bool inventoryOpen = false;
    bool chestOpen = false;

    public GameObject materializedObject = null;

    void Start()
    {
        space_count = 0;
        slots = new Item[space];
        items_count = new int[space];
    }
    

    public bool isInventoryOpen()
    {
        if (inventoryOpen || chestOpen)
            return true;
        return false;
    }

    void Update()
    {
        //"I" - Hide/Show UI
        if (Input.GetButtonDown("Inventory"))
        {
            if (!inventoryOpen)
            {
                inventoryUI.Show();
                inventoryOpen = true;
            }
            else
            {
                inventoryUI.Hide();
                inventoryOpen = false;
                if (chestOpen)
                {
                    ConnectExtension(null);
                }
            }
        }
        //"ESC" - Hide UI
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryOpen)
            {
                inventoryUI.Hide();
                inventoryOpen = false;
            }
            if (chestOpen)
            {
                ConnectExtension(null);
            }
        }

    }

    public void Select (int index)
    {
   
        if (selectedIndex != -1)
        {
            Debug.Log("Swapping " + index + " " + selectedIndex);
            Swap(index);
            return;
        }
        if(GetItemCount(index) > 0)
        {
            Debug.Log("Selected " + index);
            selectedIndex = index;
        }

    }

    void SumItems(int target, int source)
    {
        int stackSize = GetItem(target).stackSize;

        int newCount = GetItemCount(target) + GetItemCount(source);

        if (newCount <= stackSize)
        {
            Remove(source);
            SetItemCount(newCount, target);
            return;
        }
        else
        {
            SetItemCount(stackSize, target);
            SetItemCount(newCount  -stackSize, source);
        }
    }

    public void Swap (int index)
    {
        if (selectedIndex >= space ^ index >= space)
            space_count--;

        //Suming same type of item.
        if (GetItem(index) == GetItem(selectedIndex))
        {
            SumItems(index, selectedIndex);
        }
        else
        {
        Item tempItem = GetItem(index);
        int tempCount = GetItemCount(index);

        SetItem(GetItem(selectedIndex), index);
        SetItemCount(GetItemCount(selectedIndex), index);

        SetItem(tempItem,selectedIndex);
        SetItemCount(tempCount,selectedIndex);
        }

        selectedIndex = -1;
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public Item GetItem(int index)
    {
        if (index >= space)
        {
            if (extension != null)
            {
                return extension.slots[index - space];
            }
            else
            {
                Debug.Log("ERROR: Extension is not connected!");
                return null;
            }
        }
        else
            return slots[index];

    }

    public int GetItemCount(int index)
    {
        if (index >= space)
        {
            if (extension != null)
            {
                return extension.items_count[index - space];
            }
            else
            {
                Debug.Log("ERROR: Extension is not connected!");
                return -1;
            }
        }
        return items_count[index];
    }

    public void SetItem(Item item, int index)
    {
        if (index >= space)
        {
            if (extension != null)
            {
                extension.slots[index - space] = item;
                return;
            }
            else
            {
                Debug.Log("ERROR: Extension is not connected!");
                return;
            }
        }
        slots[index] = item;
    }

    public void SetItemCount(int count, int index)
    {
        if (index >= space)
        {
            if (extension != null)
            {
                extension.items_count[index - space] = count;
                return;
            }
            else
            {
                Debug.Log("ERROR: Extension is not connected!");
                return;
            }
        }
        items_count[index] = count;
    }

    public bool Add (Item item, int count)
    {
        if(count >= space)
        {
            Debug.Log("No space");
            return false;
        }

        int slot = findSlotsForItem(item, count);
        if(slot != -1){           
            items_count[slot] += count;
            if(items_count[slot] > item.stackSize)
            {
                Add(item, items_count[slot] % item.stackSize);
                items_count[slot] = item.stackSize;
            }
        }
        else {
            slot = findEmptySlot();
            slots[slot] = item;

            if(items_count[slot] <= item.stackSize)
            {
                items_count[slot] += count;
                space_count++;
            }
            else
            {
                items_count[slot] = item.stackSize;
                space_count++;
                Add(item, count-item.stackSize);
            }
        }

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        
        return true;
    }

    public void Remove(int index)
    {
        if (slots[index] != null) {
            slots[index] = null;
            items_count[index] = 0;
            space_count--;

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public void Remove(int index, int amount)
    {
        if (slots[index] != null)
        {
            if (items_count[index] == amount) { 
                Remove(index);
                return;
            }
            items_count[index] -= amount;

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    private int findSlotsForItem(Item item, int count)
    {
        //Loop through all inventory spaces
        for (int i = 0; i < space; i++)
        {
            //Check if slot isn't empty
            if (slots[i] != null) {

                if (slots[i].name == item.name && (item.stackSize > items_count[i]))
                {
                    return i;
                }
           }
        }
        return -1;
    }

    private int findEmptySlot()
    {
        for (int i = 0; i < space; i++)
        {
            if (!slots[i])
                return i;
        }
        return -1;
    }

    public void ConnectExtension(InventoryExtension extension)
    {
        this.extension = extension;
        InventoryUI.instance.SwitchUI();
        chestOpen = !chestOpen;
    }

    public void OpenInventory()
    {
        inventoryOpen = true;
    }

    
    public void Equip(int index)
    {
        if (materializedObject != null)
        {
            Unequip();
            return;
        }

        Item item = GetItem(index);
        if (item == null)
            return;

        if (item.isPlaceable)
        {

        }
        else if (item.isGun)
        {

        }
        else
        {
            materializedObject = Instantiate(GetItem(index).model, gameObject.transform, true);


            materializedObject.transform.position = item.materializedPlacement + gameObject.transform.position;
            materializedObject.transform.rotation = transform.rotation;
        }
    }

    public void Unequip()
    {
        Destroy(materializedObject);
    }

        
}
