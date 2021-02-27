using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    public LevelGenerator levelGen;
    public GameObject holder;

    public Sprite stone;
    public Sprite wood;

    private void Start()
    {
        StartCoroutine("GenerateMapRoutine");
    }

    IEnumerator GenerateMapRoutine()
    {
        ClearMap();
        if(levelGen.map != null)
            GenerateMap();
        yield return new WaitForSeconds(60);
        yield return GenerateMapRoutine();
    }
    void ClearMap()
    {
        foreach(Transform obj in holder.transform){
            Destroy(obj.gameObject);
        }
    }

    void GenerateMap()
    {
        for(int x = 0; x < 100; x++)
        {
            for (int y = 0; y < 100; y++)
            {
                if (levelGen.map[x, y] != null)
                {
                    // Create object //
                    GameObject obj = new GameObject($"{x}, {y}");
                    Image image = obj.AddComponent<Image>();
                    RectTransform transf = obj.GetComponent<RectTransform>();
                    transf.SetParent(holder.transform);
                    transf.sizeDelta = new Vector2(1, 1);
                    //Set position
                    obj.transform.position = holder.transform.position + new Vector3(x-50,y-50,0);
                    //change x and y;

                    obj.SetActive(true);
                    // Assign sprite //
                    if (levelGen.map[x, y].name.Contains("Rock"))
                    {
                        image.sprite = stone;
                    }
                    if (levelGen.map[x, y].name.Contains("Wood"))
                    {
                        image.sprite = wood;
                    }
                }
            }
        }
    }
}
