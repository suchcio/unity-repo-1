using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public GameObject waila = null;
    public Item item = null;
    public LayerMask whatCanBeClickedOn;
    public Interactable focus;
    public PlayerMotor motor;
    Interactable interactable = null;
    bool wailaDisplayActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
       //myAgent = character.GetComponent<NavMeshAgent>();
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
            }

            //Right click - Movement
            if (Input.GetMouseButtonDown(1))
            {
                    RemoveFocus();
                    motor.MoveToPoint(hit.point);
                
            }
        }
        
        if (Input.GetKeyDown("1"))
        {
            //Inventory.instance.Equip(0);
        }
        if (Input.GetKeyDown("2"))
        {
            //Inventory.instance.Equip(1);
        }
        if (Input.GetKeyDown("3"))
        {
            //Inventory.instance.Equip(2);
        }
        if (Input.GetKeyDown("4"))
        {
            //Inventory.instance.Equip(3);
        }
        if (Input.GetKeyDown("5"))
        {
            //Inventory.instance.Equip(4);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RemoveFocus();
            motor.MoveToPoint(gameObject.transform.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On trigger");
    }
    void SetFocus(Interactable newFocus)
    {
        //If new focus is different this time.
        if(newFocus != focus)
        {
            //If we already focus on something else
            if (focus != null)
                //Remove focus on old item
                focus.onDefocused();
            //Set new focus
            focus = newFocus;
            //Follow new focus
            motor.FollowTarget(newFocus);
        }
        //Focus on new
        newFocus.onFocused(transform);
        
    }
    void RemoveFocus()
    {
        //If we already focus on something else
        if (focus != null)
        {
            //Remove focus on old item
            focus.onDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
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
