//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class InputUI : MonoBehaviour
//{
//    public InputMaster controls;
//    public GameObject uiController;
//    public InputActionMap player;
//    public InputActionMap inv;

//    void Awake()
//    {
//        controls = new InputMaster();
//        controls.UI.Submit.performed += ctx => Submit();
//        controls.UI.Cancel.performed += ctx => Cancel();
//    }

//    private void Start()
//    {
//        controls.UI.Disable();
//    }

//    void Cancel()
//    {
//        controls.UI.Disable();
//        player.Enable();

//        Debug.Log("UI.cancel");
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
