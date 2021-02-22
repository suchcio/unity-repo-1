using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Gatherable
{
    public GameObject horizontal;
    public GameObject vertical;

    public int range = 10;
    public int hitradius = 1;

    public int maxAngle = 90;
    public int minAngle = -90;
    int currentAngle = 0;
    bool direction = false;


    public LineRenderer line;

    private void Start()
    {
        InvokeRepeating("ScanForEnemy", 0f, 0.05f);

    }


    void ScanForEnemy()
    {
        RotateTurret();
        RaycastHit hit;
        Vector3 target = range * -vertical.transform.up;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), target.normalized , out hit, range))// && hit.transform.tag == "Enemy")
        {
            ShootEnemy(hit);
        }

        line.SetPosition(0, vertical.transform.position);
        line.SetPosition(1, vertical.transform.position + target);

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
