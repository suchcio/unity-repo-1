using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
public class ObjectPositionPreview : Editor
{
    Item comp;
    Vector3 current_values;
    static bool showTileEditor = false;

    public void OnEnable()
    {
        comp = (Item)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorUtility.SetDirty(comp);
        if(comp.materializedRotation != current_values)
        {
            Debug.Log("ON gui!");
            current_values = comp.materializedRotation;
            //DrawDefaultInspector();
            ObjectSpawner.instance.RevisualizeObject();
        }

    }

}
