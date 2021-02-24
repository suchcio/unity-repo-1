using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : Turret
{
    public GameObject shotPrefab;
    float projectileLifeTime = 3;
    Queue<GameObject> projectiles = new Queue<GameObject>();

    public override void ShootEnemy(RaycastHit hit)
    {
        GameObject newShot = Instantiate(shotPrefab, transform);
        newShot.transform.position = vertical.transform.position;
        newShot.transform.Rotate(new Vector3(0, 90, 0));

        Rigidbody newRigidBody = newShot.AddComponent<Rigidbody>();
        newRigidBody.useGravity = false;
        newRigidBody.AddForce(-vertical.transform.up * 5000);
        //newShot.GetComponent<Rigidbody>().AddForce(vertical.transform.up * 500);
        projectiles.Enqueue(newShot);
        StartCoroutine("ProjLife");
    }

    IEnumerator ProjLife()
    {
        yield return new WaitForSeconds(projectileLifeTime);
        Destroy(projectiles.Dequeue());
    }
}
