using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    #region Singleton
    public static ObjectSpawner instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    GameObject player = null;
    public GameObject materializedObject = null;
    public GameObject buildingObject = null;

    public LayerMask ground;
    Vector3 newPos;

    void Update()
    {
        //Refresh holograph on grid
        if(buildingObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, ground))
            {
                int x = (int) Mathf.Round(hit.point.x);
                int z = (int) Mathf.Round(hit.point.z);
                newPos = new Vector3(x, 0.1f, z);
                buildingObject.transform.position = newPos;
            }
        }
    }

    public void Place()
    {
        SpawnObject(newPos);
    }

    public void SpawnObject(Vector3 position)
    {
        GameObject newObject = Instantiate(materializedObject, gameObject.transform, true);
        newObject.transform.position = position;
    }

    public void VisualizeObject(Item item)
    {
        player = Inventory.instance.gameObject.transform.parent.gameObject;
        if (materializedObject != null)
        {
            DevisualizeObject();
            return;
        }

        if (item == null)
            return;

        if (item.isPlaceable)
        {
            // Carried object
            materializedObject = Instantiate(item.model, Inventory.instance.transform, true);
            materializedObject.transform.position = player.transform.forward * 1 + player.transform.position + item.materializedPlacement;
            materializedObject.GetComponent<Interactable>().enabled = false;
            // Rotation doesnt matter for Placeable items
            //Inventory.instance.gameObject.transform.rotation = player.transform.rotation;

            //Building holograph
            buildingObject = Instantiate(item.model, gameObject.transform, true);
            buildingObject.GetComponent<Interactable>().enabled = false;

        }
        else if (item.isGun)
        {

        }
        else
        {
            materializedObject = Instantiate(item.model, gameObject.transform, true);
            materializedObject.transform.position = item.materializedPlacement + gameObject.transform.position;
            materializedObject.transform.rotation = transform.rotation;
        }
    }

    public void DevisualizeObject()
    {
        Destroy(materializedObject);
        Destroy(buildingObject);
    }
}
