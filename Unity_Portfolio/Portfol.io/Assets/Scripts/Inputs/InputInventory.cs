//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class InputInventory : MonoBehaviour
//{
//    public InputMaster controls;
//    public GameObject inventoryController;
//    public InputActionMap ui;
//    public InputActionMap player;

//    void Awake()
//    {
        
//        controls = new InputMaster();
//        controls.Inventory.Submit.performed += ctx => Submit();
//        controls.Inventory.Cancel.performed += ctx => Cancel();
//    }

//    private void Start()
//    {
//        controls.Inventory.Disable();
//    }

//    void Cancel()
//    {
//        controls.Inventory.Disable();
//        player.Enable();

//        Debug.Log("Inventory.cancel");
//    }

//    void Submit()
//    {
//        Debug.Log($"Submitted");
//    }


//    #region Enable/Disable
//    private void OnEnable()
//    {
//        controls.Enable();
//    }

//    private void OnDisable()
//    {
//        controls.Disable();
//    }
//    #endregion
//}
