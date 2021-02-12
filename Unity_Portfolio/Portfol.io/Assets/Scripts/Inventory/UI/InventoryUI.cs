using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryUI : MonoBehaviour
{
    #region Singleton
    public static InventoryUI instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryUI found!");
            return;
        }

        instance = this;
    }
    #endregion

    public GameObject selectedSlot = null;

    public Transform mainUI;
    public Transform extensionUI;
    public Transform barUI;

    public GameObject PauseUI;

    Inventory inventory;

    ChestSlot[] chest_slots;
    InventorySlot[] slots;
    InventorySlot[] bar_slots;

    int highlightedSlot = -1;

    private bool isHidden = true;

    public void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            HighlightSlot(0);
        }
        if (Input.GetKeyDown("2"))
        {
            HighlightSlot(1);
        }
        if (Input.GetKeyDown("3"))
        {
            HighlightSlot(2);
        }
        if (Input.GetKeyDown("4"))
        {
            HighlightSlot(3);
        }
        if (Input.GetKeyDown("5"))
        {
            HighlightSlot(4);
        }
    }

    public void HighlightSlot(int index)
    {
        DimSlot();
        barUI.transform.GetChild(index).GetChild(0).gameObject.transform.localScale = new Vector3(1.1f,1.1f,1.1f);
        highlightedSlot = index;
    }

    public void DimSlot()
    {
        if(highlightedSlot != -1)
            barUI.transform.GetChild(highlightedSlot).GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void SwitchUI()
    {
        if (!extensionUI)
        {
        extensionUI = gameObject.transform.Find("Layouts/Chest + Inventory/Chest");
        mainUI = gameObject.transform.Find("Layouts/Chest + Inventory/Inventory");

        }
        else
        {
            extensionUI = null;
            mainUI = gameObject.transform.Find("Layouts/Inventory");
        }

        AssignSlots();
        UpdateUI();
    }

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        AssignSlots();
    }

    void AssignSlots()
    {
        if(extensionUI)
            chest_slots = extensionUI.GetComponentsInChildren<ChestSlot>();
        slots = mainUI.GetComponentsInChildren<InventorySlot>();
        bar_slots = barUI.GetComponentsInChildren<InventorySlot>();
    }

    public void Show()
    {
        if (extensionUI != null)
            extensionUI.gameObject.SetActive(true);
        isHidden = false;
        barUI.gameObject.SetActive(false);
        mainUI.gameObject.SetActive(true);
        PauseUI.SetActive(false);
    }
    /// <summary>
    /// If not already hidden, hide all UI and show BAR ui.
    /// </summary>
    public void Hide()
    {
        if (!isHidden)
        {
            isHidden = true;
            mainUI.gameObject.SetActive(false);
            barUI.gameObject.SetActive(true);
            PauseUI.SetActive(true);
            if (extensionUI != null)
            {
                extensionUI.gameObject.SetActive(false);
            }
        }
    }
    /// <summary>
    ///  Update chest and inventory and bar slots
    /// </summary>
    void UpdateUI()
    {
        if (inventory.extension != null)
            UpdateExtensionUI();
        for(int i = 0; i < slots.Length; i++)
        {
            if (inventory.selectedIndex == i)
            {
                //do something
            }
            if (inventory.slots[i] != null)
            {
                slots[i].AddItem(inventory.slots[i]);
                slots[i].SetCount(inventory.items_count[i]);
                if (i < 5) { 
                    bar_slots[i].AddItem(inventory.slots[i]);
                    bar_slots[i].SetCount(inventory.items_count[i]);
                }
            }
            else
            {
                slots[i].ClearSlot();
                if (i < 5) { 
                    bar_slots[i].ClearSlot();
                }
            }
        }
    }

    /// <summary>
    /// Update position/counts of items in chest
    /// </summary>
    void UpdateExtensionUI()
    {
        int len = slots.Length;
        for (int i = 0; i < chest_slots.Length; i++)
        {
            if (inventory.selectedIndex == i)
            {
                //do something
            }
            if (inventory.GetItem(i+len) != null)
            {
                chest_slots[i].AddItem(inventory.GetItem(i+len));
                chest_slots[i].SetCount(inventory.GetItemCount(i+len));
            }
            else
            {
                chest_slots[i].ClearSlot();
            }
        }
    }
}
