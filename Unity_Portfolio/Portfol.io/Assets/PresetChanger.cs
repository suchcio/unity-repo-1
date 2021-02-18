using cakeslice;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class PresetChanger : MonoBehaviour
{
    public OutlineEffect outlineEffect;
    public Preset holograph;
    public Preset outline;
    string currentPreset = "outline";
    Camera outlineCamera;

    #region Singleton
    public static PresetChanger instance;

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

    public void setHolographPreset()
    {
        if(currentPreset == "outline")
        {
            outlineCamera = outlineEffect.outlineCamera;
            holograph.ApplyTo(outlineEffect);
            currentPreset = "holograph";
            loadCameras();
        }
    }

    void loadCameras()
    {
        outlineEffect.outlineCamera = outlineCamera;
        outlineEffect.sourceCamera = Camera.main;
    }

    public void setOutlinePreset()
    {
        if(currentPreset == "holograph")
        {
            outlineCamera = outlineEffect.outlineCamera;
            outline.ApplyTo(outlineEffect);
            currentPreset = "outline";
            loadCameras();
        }
    }
}
