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

    int currentAngle = 0;
    bool direction = false;

    public LineRenderer line;
    public GameObject visualizePrefab;
    GameObject holder;
    float chordLength;

    private void Start()
    {
        // circularSegmentHeight = range * (1 - Mathf.Cos(Mathf.Deg2Rad * hitAngle / 2));
        chordLength = ((int)(2 * range * Mathf.Sin(Mathf.Deg2Rad * hitAngle / 2)));
        line.widthMultiplier = chordLength;

        line.enabled = true;
        InvokeRepeating("ScanForEnemy", 0f, 0.05f);
        InvokeRepeating("visualize", 0f, 2f);

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
    
    
    void ScanForEnemy()
    {
        //RotateTurret();
        RaycastHit hit;
        RaycastHit[] hits;

        Vector3 rayTargetPoint = range * -vertical.transform.up;

        //If I want to have circular segment
        // Vector3 visTargetPoint = (range - chordLength/2) * -vertical.transform.up;
        //Else
        Vector3 visTargetPoint = (range) * -vertical.transform.up;
        //

        line.SetPosition(0, vertical.transform.position);
        line.SetPosition(1, vertical.transform.position + visTargetPoint);

        //if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), rayTargetPoint.normalized, out hit, range))// && hit.transform.tag == "Enemy")
        //{
        //    hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1f);
        //}

        for(int i = -hitAngle; i <= hitAngle; i++)
        {
            //If I want to NOT have circular segment in Raycast.
            rayTargetPoint = (range - (1 - Mathf.Cos(Mathf.Deg2Rad/2 * (-i + Mathf.Abs(hitAngle))))) * -vertical.transform.up;
            //

            Vector3 rotatedRayTargetPoint = Quaternion.AngleAxis(i/2, Vector3.up) * rayTargetPoint;

            if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), rotatedRayTargetPoint.normalized, out hit, range))// && hit.transform.tag == "Enemy")
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1f);
            }
        }

        //Visual representation in Scene view
        //Debug.DrawLine(transform.position + new Vector3(0, 1, 0),  transform.position + new Vector3(range * vertical.transform.forward.normalized.x, 1, range * vertical.transform.forward.normalized.z), new Color(255, 0, 0), 1f);
        //Debug.Log($"Location of target {transform.position + new Vector3(range * vertical.transform.localRotation.eulerAngles.x, vertical.transform.localRotation.eulerAngles.y, range * vertical.transform.localRotation.eulerAngles.z)}");
    }

    void FindNearestEnemy()
    {

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

    void ShootEnemy(RaycastHit hit)
    {
        Debug.Log($"Hit {hit.transform.name}");
        
    }
}
