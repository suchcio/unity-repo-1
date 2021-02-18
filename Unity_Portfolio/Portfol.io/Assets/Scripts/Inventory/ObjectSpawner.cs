using cakeslice;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public GameObject[] buildingObjects = null;
    Camera cam;

    public MapGenerator mapGenerator;
    public LayerMask ground;
    Vector3 holdPoint;
    Vector3 newPos;
    Item equippedItem;

    bool buildingWall = false;

    private void Start()
    {
        cam = Camera.main;
        holdPoint = new Vector3(0.1f, 0.1f, 0.1f);
    }

    void Update()
    {
        //Refresh holograph on grid
        if(buildingObjects.Length >= 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, ground))
            {
                int x = (int) Mathf.Round(hit.point.x);
                int z = (int) Mathf.Round(hit.point.z);
                newPos = new Vector3(x, 0.1f, z);
                //Move object 1 together with mouse cursor.
                buildingObjects[0].transform.position = newPos;
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
        newObject.GetComponent<Interactable>().enabled = true;
    }
    
    public void VisualizeWall()
    {
        if (!equippedItem.isPlaceable)
            return;

        PresetChanger.instance.setHolographPreset();

        buildingWall = true;

        if (buildingObjects.Length == 0)
        {
            StopCoroutine("HoldInteract");
            return;
        }
        Ray myRay = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(myRay, out hit, 100))
        { 
            int x = (int)Mathf.Round(hit.point.x);
            int z = (int)Mathf.Round(hit.point.z);
            if (holdPoint == new Vector3(0.1f, 0.1f, 0.1f))
                holdPoint = new Vector3(x, 0.1f, z);
            Vector3 newPoint = new Vector3(x, 0.1f, z);

            if(holdPoint != newPoint)
            {
                Debug.Log("Different location .. spawning objects");
                int index = 0;
                var list = MapGenerator.GetPointsOnLine(holdPoint, new Vector3(x, 0.1f, z));

                // Destroy all objects on loop
                DevisualizeHolographedObjects();

                // Recover mouse aligned object
                VisualizeObject(equippedItem);
                buildingObjects[0].transform.position = newPoint;

                foreach (var val in list.ToList())
                {
                    //Spawn objects
                    VisualizeObject(equippedItem);
                    //Update positions for all new walls
                    buildingObjects[index++].transform.position = val;
                }
            }
        }
    }

    public void VisualizeObject(Item item)
    {
        equippedItem = item;

        player = Inventory.instance.gameObject.transform.parent.gameObject;
        if (materializedObject != null && !buildingWall)
        {
            DevisualizeHolographedObjects();
            return;
        }

        if (equippedItem == null)
        {
            equippedItem = item;
        }

        if (item == null)
            return;

        if (item.isPlaceable)
        {
            
            //Carried object
            if(buildingObjects.Length == 0)
            {
                materializedObject = Instantiate(equippedItem.model, Inventory.instance.transform, true);
                materializedObject.transform.position = player.transform.forward * 1 + player.transform.position + equippedItem.materializedPlacement;
                materializedObject.GetComponent<Interactable>().enabled = false;
                buildingObjects = new GameObject[1];
            }
            else
            {
                Array.Resize(ref buildingObjects, buildingObjects.Length + 1);

                //Preparing holograph outline in holograph
                var outlines = equippedItem.model.GetComponentsInChildren<Outline>();
                foreach (var outline in outlines)
                    outline.enabled = true;
            }

            //Building holograph
            buildingObjects[buildingObjects.Length - 1] = Instantiate(equippedItem.model, gameObject.transform, true);
            buildingObjects[buildingObjects.Length - 1].GetComponent<Interactable>(); // Slow change to item.model.interactable instead
            //interactable.enabled = false;

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

    public void DevisualizeHolographedObjects()
    {
        foreach(var obj in buildingObjects){
            Destroy(obj);
        }
        buildingObjects = new GameObject[0];
    }

    public void DevisualizeMaterializedObject()
    {
        Destroy(materializedObject);
        materializedObject = null;
    }
}
