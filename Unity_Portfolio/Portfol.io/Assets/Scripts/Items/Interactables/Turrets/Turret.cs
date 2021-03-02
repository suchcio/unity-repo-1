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
    public int maxPierce = 2;

    Quaternion startingRotation;
    int currentAngle = 0;
    bool direction = false;
    bool onCooldown = false;

    public GameObject visualizePrefab;
    GameObject holder;
    LineRenderer line;
    float chordLength;
    bool shootAble = false;

    List<GameObject> exposedEnemy;
    List<GameObject> unexposedEnemy;
    List<GameObject> collidingObject;

    private void Start()
    {
        exposedEnemy = new List<GameObject>();
        unexposedEnemy = new List<GameObject>();
        collidingObject = new List<GameObject>();

        line = GetComponent<LineRenderer>();
        startingRotation = vertical.transform.rotation;
        chordLength = ((int)(2 * range * Mathf.Sin(Mathf.Deg2Rad * hitAngle / 2)));
        line.widthMultiplier = chordLength;

        line.enabled = true;
        InvokeRepeating("ScanForEnemy", 0f, 0.05f);
        InvokeRepeating("RotateTurret", 0f, 0.05f);
    }
    
    
    IEnumerator shotCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(shootCooldown);
        onCooldown = false;
    }
    
    void ScanForEnemy()
    {
        RaycastHit[] hits;

        Vector3 rayTargetPoint = range * -vertical.transform.up;

        //If I want to have circular segment
        // Vector3 visTargetPoint = (range - chordLength/2) * -vertical.transform.up;
        //Else
        Vector3 visTargetPoint = (range) * -vertical.transform.up;
        //

        line.SetPosition(0, vertical.transform.position);
        line.SetPosition(1, vertical.transform.position + visTargetPoint);

        ClearTargets();

        for(int i = -hitAngle; i <= hitAngle; i++)
        {
            //If I want to NOT have circular segment in Raycast. For some reason its broken https://planetcalc.com/1421/
            //rayTargetPoint = (range - (1 - Mathf.Cos(Mathf.Deg2Rad/2 * (-i + Mathf.Abs(hitAngle))))) * -vertical.transform.up;

            Vector3 rotatedRayTargetPoint = Quaternion.AngleAxis(i/2, Vector3.up) * rayTargetPoint;

            //Move this out of the loop.
            hits = Physics.RaycastAll(transform.position + new Vector3(0, 0.5f, 0), rotatedRayTargetPoint.normalized, range);
            if (hits.Length > 0)
            {
                SegregateTargets(hits, i);
            }
        }

        if (exposedEnemy.Count == 0)
        {
            if (!IsInvoking("RotateTurret"))
            {
                ResetTurretRotation();
                InvokeRepeating("RotateTurret", 0f, 0.05f);
                Debug.Log("Begining rotation");
            }
        }
        else
        {
            GameObject nearestEnemy = FindNearestEnemy(exposedEnemy.ToArray());
            FaceEnemy(nearestEnemy, vertical.transform);
            FaceEnemy(nearestEnemy, horizontal.transform);
            if (!onCooldown)
            {
                StartCoroutine("shotCooldown");
                if(shootAble)
                    ShootEnemy(nearestEnemy);
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

    //public void FaceEnemy(RaycastHit nearestEnemy, Transform obj)
    //{
    //    CancelInvoke("RotateTurret");
    //    Quaternion oldRotation = obj.rotation;
    //    var lookPos = nearestEnemy.transform.position - obj.position;
    //    lookPos.y = 0;

    //    var rotation = Quaternion.LookRotation(lookPos);
    //    obj.rotation = Quaternion.Slerp(horizontal.transform.rotation, rotation, Time.deltaTime * 5f);
    //    obj.rotation = Quaternion.Euler(new Vector3(oldRotation.eulerAngles.x, obj.rotation.eulerAngles.y, oldRotation.eulerAngles.z));
    //}

    public void FaceEnemy(GameObject nearestEnemy, Transform obj)
    {
        CancelInvoke("RotateTurret");
        Quaternion oldRotation = obj.rotation;
        var lookPos = nearestEnemy.transform.position - obj.position;
        lookPos.y = 0;

        var rotation = Quaternion.LookRotation(lookPos);
        obj.rotation = Quaternion.Slerp(horizontal.transform.rotation, rotation, Time.deltaTime * 5f);
        obj.rotation = Quaternion.Euler(new Vector3(oldRotation.eulerAngles.x, obj.rotation.eulerAngles.y, oldRotation.eulerAngles.z));
    }



    GameObject FindNearestEnemy(GameObject[] hits)
    {
        int index = 0;
        float distance = Vector3.Distance(transform.position, hits[0].transform.position);
        GameObject nearestEnemy = hits[0];

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

    //RaycastHit FindNearestEnemy(RaycastHit[] hits)
    //{
    //    int index = 0;
    //    float distance = Vector3.Distance(transform.position, hits[0].transform.position);
    //    RaycastHit nearestEnemy = hits[0];

    //    foreach (var hitTarget in hits)
    //    {
    //        if (hitTarget.transform.tag != "Enemy")
    //            continue;
    //        float newDistance = Vector3.Distance(transform.position, hitTarget.transform.position);
    //        if (newDistance < distance)
    //        {
    //            distance = newDistance;
    //            nearestEnemy = hits[index++];
    //        }
    //    }
    //    return nearestEnemy;
    //}

    void SegregateTargets(RaycastHit[] hits, int index)
    {
        bool behindWall = false;
        for(int i = 0; i < hits.Length; i++)
        //for(int i = hits.Length - 1; i >= 0; i--)
        //foreach (var hit in hits)
        {
            // Wall
            if (hits[i].transform.tag == "Wall")
            {
                behindWall = true;
                collidingObject.Add(hits[i].transform.gameObject);
            }
            else if (hits[i].transform.tag == "Enemy")
            {
                //If not behind wall
                if (!behindWall)
                {
                    exposedEnemy.Add(hits[i].transform.gameObject);
                    shootAble = true;
                }
                else
                {
                    unexposedEnemy.Add(hits[i].transform.gameObject);
                    shootAble = false;
                }
            }
        }
    }

    void ClearTargets()
    {
        collidingObject.Clear();
        exposedEnemy.Clear();
        unexposedEnemy.Clear();
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

    //public virtual void ShootEnemy(RaycastHit hit) { }

    public virtual void ShootEnemy(GameObject hit) { }
}
