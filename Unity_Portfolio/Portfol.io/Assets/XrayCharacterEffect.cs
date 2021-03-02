using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrayCharacterEffect : MonoBehaviour
{
    Camera cam;
    RaycastHit hit;
    GameObject target;
    public LayerMask mylayermask;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        target = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(cam.transform.position, (target.transform.position - cam.transform.position).normalized, out hit, Mathf.Infinity, mylayermask))
        {
            Debug.Log(hit.collider.gameObject.tag);
            if(hit.collider.gameObject.tag == "SphereMask")
            {
                target.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                target.transform.localScale = new Vector3(3, 3, 3);
            }
        }
    }
}
