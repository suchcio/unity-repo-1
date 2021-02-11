using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
    public GameObject character;

    void Start()
    {
        agent = character.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
        }
        
    }


    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;
        target = newTarget.interactionTransform;

    }


    public void StopFollowingTarget()
    {
        target = null;
        agent.stoppingDistance = 0;
        Debug.Log("Stopped");
    }

}
