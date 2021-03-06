﻿using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Item item;
    public Transform interactionTransform;
    public Outline[] outlines;

    public bool isFocus = false;
    public bool hasInteracted = false;
    public Transform player;


    public virtual void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = vector2DDistance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    private float vector2DDistance(Vector3 v1, Vector3 v2)
    {
        float xDiff = v1.x - v2.x;
        float zDiff = v1.z - v2.z;
        return Mathf.Sqrt((xDiff * xDiff) + (zDiff * zDiff));
    }

    public void OnFocused(Transform playerTransform)
    {

        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public virtual void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);

    }

    public virtual void Interact()
    {

    }
}
