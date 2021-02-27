using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : Turret
{
    public GameObject shotPrefab;
    public float projectileLifeTime = 3;
    public int projectileSpeed = 1000;
    Queue<GameObject> projectiles = new Queue<GameObject>();

    //public override void ShootEnemy(RaycastHit hit)
    //{
    //    GameObject newShot = Instantiate(shotPrefab, transform);
    //    newShot.transform.position = vertical.transform.position;
    //    newShot.transform.Rotate(new Vector3(0, 90, 0));
    //    FaceEnemy(hit, newShot.transform);

    //    Rigidbody newRigidBody = newShot.AddComponent<Rigidbody>();
    //    newRigidBody.useGravity = false;
    //    newRigidBody.AddForce(-vertical.transform.up * projectileSpeed);
    //    //newShot.GetComponent<Rigidbody>().AddForce(vertical.transform.up * 500);
    //    projectiles.Enqueue(newShot);
    //    StartCoroutine("ProjLife");
    //}

    public override void ShootEnemy(GameObject hit)
    {
        GameObject newShot = Instantiate(shotPrefab, transform);
        newShot.transform.position = vertical.transform.position;
        newShot.transform.Rotate(new Vector3(0, 90, 0));
        FaceEnemy(hit, newShot.transform);

        Rigidbody newRigidBody = newShot.AddComponent<Rigidbody>();
        newRigidBody.useGravity = false;
        newRigidBody.AddForce(-vertical.transform.up * projectileSpeed);
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
