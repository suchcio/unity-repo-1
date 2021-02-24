using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using cakeslice;
using UnityEditor.Presets;

public class PlayerController : MonoBehaviour
{
    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChangedCallback;
    public Interactable focus;
    public PresetChanger outlinePreset;
    public GameObject waila = null;
    Camera cam;
    PlayerMotor motor;
    Interactable interactable = null;
    Interactable oldinteractable = null;
    bool wailaDisplayActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Confined;
        motor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        Ray myRay = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, 100))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null && wailaDisplayActive == false)
            {
                Highlight();
            }
            else if (wailaDisplayActive == true && interactable == null)
            {
                Dim();
            }
        }
    }

    public void Build()
    {
        if (ObjectSpawner.instance.buildingObjects.Length > 0)
        {
            ObjectSpawner.instance.Place();
            Inventory.instance.Remove();
        }
    }

    // Set our focus to a new focus
    public void SetFocus(Interactable newFocus)
    {
        if (onFocusChangedCallback != null)
            onFocusChangedCallback.Invoke(newFocus);

        // If our focus has changed
        if (focus != newFocus && focus != null)
        {
            // Let our previous focus know that it's no longer being focused
            focus.OnDefocused();
        }

        // Set our focus to what we hit
        // If it's not an interactable, simply set it to null
        focus = newFocus;

        if (focus != null)
        {
            // Let our focus know that it's being focused
            focus.OnFocused(transform);
        }

    }

    public void SetFocus()
    {
        if (interactable == null || !interactable.isActiveAndEnabled)
            return;

        Interactable newFocus = interactable;

        if (onFocusChangedCallback != null)
            onFocusChangedCallback.Invoke(newFocus);

        // If our focus has changed
        if (focus != newFocus && focus != null)
        {
            // Let our previous focus know that it's no longer being focused
            focus.OnDefocused();
        }

        // Set our focus to what we hit
        // If it's not an interactable, simply set it to null
        focus = newFocus;

        if (focus != null)
        {
            // Let our focus know that it's being focused
            focus.OnFocused(transform);
        }

    }

    public void NullFocus()
    {
        if (onFocusChangedCallback != null)
            onFocusChangedCallback.Invoke(null);

        if (focus != null)
        {
            focus.OnDefocused();
        }

        focus = null;

        motor.MoveToPoint(transform.position);
    }

    void Highlight()
    {
        waila.GetComponentsInChildren<Image>()[1].sprite = interactable.item.icon;
        waila.GetComponentsInChildren<TextMeshProUGUI>()[0].text = interactable.item.name;
        waila.SetActive(true);

        foreach(var outline in interactable.outlines)
            outline.enabled = true;
        oldinteractable = interactable;
        wailaDisplayActive = true;

    }
   
    void Dim()
    {
        //Check if interacted object was destroyed
        if (oldinteractable != null)
            foreach (var outline in oldinteractable.outlines)
                outline.enabled = false;
        wailaDisplayActive = false;
        waila.SetActive(false);
    }

}
