using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChangedCallback;
    public Interactable focus;

    public GameObject waila = null;
    public Item item = null;
    public LayerMask whatCanBeClickedOn;
    PlayerMotor motor;
    Interactable interactable = null;
    bool wailaDisplayActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, 100))
        {
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


        //Mouse actions when player is has no windows open.
        if (!Inventory.instance.isInventoryOpen())
        {
            //Left click - Action
            if (Input.GetMouseButtonDown(0))
            {
                if (interactable != null)
                {
                    SetFocus(interactable);
                }

                //Place object in the world.
                if (ObjectSpawner.instance.buildingObject != null)
                {
                    ObjectSpawner.instance.Place();
                    Inventory.instance.Remove();
                }
            }

            //Right click - Movement
            if (Input.GetMouseButtonDown(1))
            {
                SetFocus(null);
                motor.MoveToPoint(hit.point);
            }
        }
        
        if (Input.GetKeyDown("1"))
        {
            Inventory.instance.Equip(0);
        }
        if (Input.GetKeyDown("2"))
        {
            Inventory.instance.Equip(1);
        }
        if (Input.GetKeyDown("3"))
        {
            Inventory.instance.Equip(2);
        }
        if (Input.GetKeyDown("4"))
        {
            Inventory.instance.Equip(3);
        }
        if (Input.GetKeyDown("5"))
        {
            Inventory.instance.Equip(4);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetFocus(null);
            motor.MoveToPoint(gameObject.transform.position);
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    motor.MoveToPoint(gameObject.transform.position);
    //    motor.StopFollowingTarget();
    //}

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

    void Highlight()
    {

        //rs = highlight.transform.GetComponentsInChildren<Renderer>();

        //foreach (Renderer renderer in rs)
        //{
        //    oldColor.Add(renderer.GetComponent<Renderer>().material.color);
        //    renderer.material.color = new Color32((byte)r, (byte)g, (byte)b, 255);
        //}

        waila.GetComponentsInChildren<Image>()[1].sprite = interactable.item.icon;
        waila.GetComponentsInChildren<TextMeshProUGUI>()[0].text = interactable.item.name;
        waila.SetActive(true);
        wailaDisplayActive = true;

    }
    void Dim()
    {
        wailaDisplayActive = false;
        waila.SetActive(false);
    }

}
