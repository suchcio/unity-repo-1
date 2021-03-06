﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
    Camera cam;
    private Animator anim;

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        anim = transform.Find("KnightCharacter").GetComponent<Animator>();
        GetComponent<PlayerController>().onFocusChangedCallback += OnFocusChanged;
    }

    

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void MoveToMousePosition()
    {
        Ray myRay = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, 100))
        {
            MoveToPoint(hit.point);
        }
    }

    void OnFocusChanged(Interactable newFocus)
    {

        if (newFocus != null)
        {
            agent.stoppingDistance = newFocus.radius;
            //agent.updateRotation = false;
            target = newFocus.interactionTransform;

            //Move without following
            MoveToPoint(target.position);
        }
        else
        {
            agent.stoppingDistance = 0f;
            //agent.updateRotation = true;
            target = null;
        }
    }

    void FacePosition(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        Debug.Log("Position :" + position + "Direction " + direction);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }



    void Update()
    {
        //Uncomment this if you want perma following target.

        //if (target != null)
        //{
        //   MoveToPoint(target.position);
        //   FaceTarget();

        if (agent.pathStatus == NavMeshPathStatus.PathComplete && (agent.remainingDistance <= agent.stoppingDistance) || agent.remainingDistance < 0.1)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
        //}

    }
}
