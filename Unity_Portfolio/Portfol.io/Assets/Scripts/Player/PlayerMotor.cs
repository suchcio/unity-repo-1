using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerController))]
public class PlayerMotor : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = transform.Find("KnightCharacter").GetComponent<Animator>();
        GetComponent<PlayerController>().onFocusChangedCallback += OnFocusChanged;
    }

    

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    void OnFocusChanged(Interactable newFocus)
    {

        if (newFocus != null)
        {
            agent.stoppingDistance = newFocus.radius;
            agent.updateRotation = false;

            target = newFocus.interactionTransform;
        }
        else
        {
            agent.stoppingDistance = 0f;
            agent.updateRotation = true;
            target = null;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void Update()
    {
        if (target != null)
        {
            MoveToPoint(target.position);
            FaceTarget();

            if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance < 0.1)
                anim.SetBool("isRunning", false);
            else
                anim.SetBool("isRunning", true);
        }
    }
}
