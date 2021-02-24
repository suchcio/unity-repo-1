using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Gatherable
{
    private Physics physics;

    public GameObject horizontal;
    public GameObject vertical;

    public int range = 10;
    public int hitAngle = 15;
    public int maxAngle = 90;
    public int minAngle = -90;
    public int dispersion = 0;
    public int shootCooldown = 3;

    Quaternion startingRotation;
    int currentAngle = 0;
    bool direction = false;
    bool onCooldown = false;

    public GameObject visualizePrefab;
    GameObject holder;
    LineRenderer line;
    float chordLength;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        startingRotation = vertical.transform.rotation;
        //circularSegmentHeight = range * (1 - Mathf.Cos(Mathf.Deg2Rad * hitAngle / 2));
        chordLength = ((int)(2 * range * Mathf.Sin(Mathf.Deg2Rad * hitAngle / 2)));
        line.widthMultiplier = chordLength;

        line.enabled = true;
        InvokeRepeating("ScanForEnemy", 0f, 0.05f);
        InvokeRepeating("RotateTurret", 0f, 0.05f);
        //InvokeRepeating("visualize", 0f, 2f);

        //Wall visualizer
        holder = Instantiate(new GameObject());
        
    }
    
    void visualize()
    {
        foreach(Transform obj in holder.gameObject.transform)
        {
            Destroy(obj.gameObject);
        }

        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                GameObject newObj = Instantiate(visualizePrefab, holder.transform);
                newObj.transform.name = $"{i} {j}";
                newObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                newObj.transform.localPosition = new Vector3(0.1f * i + 3.5f, 0.5f, 0.1f * j - 10);
            }
        }
    }
    
    IEnumerator shotCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        onCooldown = false;
    }
    
    void ScanForEnemy()
    {
        RaycastHit hit;
        RaycastHit[] hits;
        bool foundEnemy = false;

        Vector3 rayTargetPoint = range * -vertical.transform.up;

        //If I want to have circular segment
        // Vector3 visTargetPoint = (range - chordLength/2) * -vertical.transform.up;
        //Else
        Vector3 visTargetPoint = (range) * -vertical.transform.up;
        //

        line.SetPosition(0, vertical.transform.position);
        line.SetPosition(1, vertical.transform.position + visTargetPoint);

        for(int i = -hitAngle; i <= hitAngle; i++)
        {
            //If I want to NOT have circular segment in Raycast. For some reason its broken https://planetcalc.com/1421/
            //rayTargetPoint = (range - (1 - Mathf.Cos(Mathf.Deg2Rad/2 * (-i + Mathf.Abs(hitAngle))))) * -vertical.transform.up;

            Vector3 rotatedRayTargetPoint = Quaternion.AngleAxis(i/2, Vector3.up) * rayTargetPoint;

            //Move this out of the loop.
            hits = Physics.RaycastAll(transform.position + new Vector3(0, 0.5f, 0), rotatedRayTargetPoint.normalized, range);
            if (hits.Length > 0)
            {
                RaycastHit nearestEnemy = FindNearestEnemy(hits);
                TargetEnemy(nearestEnemy);
                if (!onCooldown)
                {
                    StartCoroutine("shotCooldown");
                    ShootEnemy(nearestEnemy);
                }
                foundEnemy = true;
                break;
            }
        }

        if (!foundEnemy)
        {
            if (!IsInvoking("RotateTurret"))
            {
                ResetTurretRotation();
                InvokeRepeating("RotateTurret", 0f, 0.05f);
                Debug.Log("Begining rotation");
            }
        }
    }

    void ResetTurretRotation()
    {
        vertical.transform.rotation = startingRotation;
        horizontal.transform.rotation = startingRotation;
        vertical.transform.Rotate(new Vector3(0, 0, currentAngle));
        horizontal.transform.Rotate(new Vector3(0, 0, currentAngle));
    }

    private void TargetEnemy(RaycastHit nearestEnemy)
    {
        CancelInvoke("RotateTurret");
        Quaternion oldRotation = horizontal.transform.rotation;
        var lookPos = nearestEnemy.transform.position - transform.position;
        lookPos.y = 0;

        //Mid part
        var rotation = Quaternion.LookRotation(lookPos);
        horizontal.transform.rotation = Quaternion.Slerp(horizontal.transform.rotation, rotation, Time.deltaTime * 5f);
        horizontal.transform.rotation = Quaternion.Euler(new Vector3(oldRotation.eulerAngles.x, horizontal.transform.rotation.eulerAngles.y, oldRotation.eulerAngles.z));
        //Top part
        vertical.transform.rotation = Quaternion.Slerp(vertical.transform.rotation, rotation, Time.deltaTime * 5f);
        vertical.transform.rotation = Quaternion.Euler(new Vector3(oldRotation.eulerAngles.x, vertical.transform.rotation.eulerAngles.y, oldRotation.eulerAngles.z));
    }

    //Single raycast
    //if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), rotatedRayTargetPoint.normalized, out hit, range))// && hit.transform.tag == "Enemy") -

    RaycastHit FindNearestEnemy(RaycastHit[] hits)
    {
        int index = 0;
        float distance = Vector3.Distance(transform.position, hits[0].transform.position);
        RaycastHit nearestEnemy = hits[0];

        foreach (var hitTarget in hits)
        {
            if (hitTarget.transform.tag != "Enemy")
                continue;
            float newDistance = Vector3.Distance(transform.position, hitTarget.transform.position);
            if (newDistance < distance)
            {
                distance = newDistance;
                nearestEnemy = hits[index++];
            }
        }
        return nearestEnemy;
    }
    
    void RotateTurret()
    {
        if(currentAngle == maxAngle || currentAngle == minAngle)
        {
            direction = !direction;
        }

        if(direction == false)
        {
            horizontal.transform.Rotate(new Vector3(0, 0, 1f));
            vertical.transform.Rotate(new Vector3(0, 0, 1f));
            currentAngle++;
        }
        else if(direction == true)
        {
            horizontal.transform.Rotate(new Vector3(0, 0, -1f));
            vertical.transform.Rotate(new Vector3(0, 0, -1f));
            currentAngle--;
        }


    }

    public virtual void ShootEnemy(RaycastHit hit) { }
}
