using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class InputGameplay : MonoBehaviour
{
    public PlayerInput playerInput;
    public InputMaster controls;
    public PlayerController playerController;
    public UnityEvent walk,interact,holdinteract,i1,i2,i3,i4,i5,cancel,inventory;


    //private void Update()
    //{
    //    Keyboard kb = InputSystem.GetDevice<Keyboard>();
    //    if (kb.spaceKey.wasPressedThisFrame)
    //    {
    //        controls.Player.Disable();
    //        Debug.Log("Deactived Gameplay UI");
    //    }
    //}

    void Awake()
    {
        controls = new InputMaster();
        //controls.Player.Walk.performed += ctx => Walk(ctx.ReadValue<Vector2>());
        controls.Player.Walk.performed += ctx => Walk();
        controls.Player.HoldWalk.performed += ctx => WalkingCoroutine();
        controls.Player.Interact.performed += ctx => Interact();
        controls.Player.Cancel.performed += ctx => Cancel();
        controls.Player.Inventory.performed += ctx => Inventory();
        controls.Player.PressRelease.performed += ctx => StopCoroutine("HoldWalk");
        controls.Player.HoldInteract.performed += ctx => InteractingCoroutine();

        controls.Player.Item1.performed += ctx => Item1();
        controls.Player.Item2.performed += ctx => Item2();
        controls.Player.Item3.performed += ctx => Item3();
        controls.Player.Item4.performed += ctx => Item4();
        controls.Player.Item5.performed += ctx => Item5();
    }

    void Item1() => i1.Invoke();
    void Item2() => i2.Invoke();
    void Item3() => i3.Invoke();
    void Item4() => i4.Invoke();
    void Item5() => i5.Invoke();
    void Interact() => interact.Invoke();
    void Inventory() => inventory.Invoke();
    void Cancel() => cancel.Invoke();
    void Walk() => walk.Invoke();


    void Pause()
    {
        controls.Player.Disable();
        //ui.Enable();
        Debug.Log("Player.pause");
    }

    IEnumerator HoldInteract()
    {
        holdinteract.Invoke();
        yield return new WaitForSeconds(0.1f);
        yield return HoldInteract();
    }


    void InteractingCoroutine()
    {
        StartCoroutine("HoldInteract");
        Debug.Log("Starting interacting coroutine");
    }

    IEnumerator HoldWalk()
    {
        walk.Invoke();
        yield return new WaitForSeconds(0.1f);
        yield return HoldWalk();
    }


    void WalkingCoroutine()
    {
        walk.Invoke();
        StartCoroutine("HoldWalk");
        Debug.Log("Starting walking coroutine");
    }

    #region Enable/Disable
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    #endregion
}
