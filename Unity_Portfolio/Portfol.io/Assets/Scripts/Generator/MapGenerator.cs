using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Transform wallPrefab;
    public Vector2 mapSize;

    [Range(0,1)]
    public float outlinePercent;

    void Start()
    {
        Transform HolderWall = CreateHolder("Walls");

        GenerateMapWithRotation();
        //NavMeshBuilder.BuildNavMesh();
    }
    Transform CreateHolder(string HolderName)
    {
        if (transform.Find(HolderName))
        {
            DestroyImmediate(transform.Find(HolderName).gameObject);
        }
        Transform mapHolder = new GameObject(HolderName).transform;
        mapHolder.parent = transform;
        return mapHolder;
    }

    void GenerateBoxWithRotation(Vector3 pointA, Vector3 pointB, Transform Holder)
    {
        float directionX = 0, directionZ = 0;
        float distanceX = pointB.x - pointA.x;
        float distanceZ = pointB.z - pointA.z;

        if(distanceX != 0)
            directionX = distanceX / Mathf.Abs(distanceX);
        if(distanceZ != 0)
            directionZ = distanceZ / Mathf.Abs(distanceZ);

        for (int x = 0; x < (int)Mathf.Abs(distanceX); x++)
        {
            Transform newWall = Instantiate(wallPrefab, new Vector3(0.5f,0,0) + pointA + (new Vector3(1,0,0) * x * (int)directionX), Quaternion.identity);
            newWall.parent = Holder;
            if(distanceX != 0 && distanceZ != 0)
            {
                newWall = Instantiate(wallPrefab, new Vector3(-0.5f, 0, 0) + pointB + (new Vector3(1, 0, 0) * x * (int)directionX * -1), Quaternion.identity);
                newWall.parent = Holder;
            }
        }

        for (int z = 0; z < (int)Mathf.Abs(distanceZ); z++)
        {
            Transform newWall = Instantiate(wallPrefab, new Vector3(0,0,0.5f) + pointA + (new Vector3(0, 0, 1) * z * (int)directionZ), Quaternion.Euler(Vector3.up * 90));
            newWall.parent = Holder;
            if (distanceX != 0 && distanceZ != 0)
            {
                newWall = Instantiate(wallPrefab, new Vector3(0, 0, -0.5f) + pointB + (new Vector3(0, 0, 1) * z * (int)directionZ * -1), Quaternion.Euler(Vector3.up * 90));
                newWall.parent = Holder;
            }
        }


    }

    public static IEnumerable<Vector3> GetPointsOnLine(Vector3 pointA, Vector3 pointB)
    {
        //http://ericw.ca/notes/bresenhams-line-algorithm-in-csharp.html
        bool steep = Mathf.Abs(pointB.z - pointA.z) > Mathf.Abs(pointB.x - pointA.x);
        if (steep)
        {
            float t;
            t = pointA.x; // swap pointA.x and pointA.z
            pointA.x = pointA.z;
            pointA.z = t;
            t = pointB.x; // swap pointB.x and pointB.z
            pointB.x = pointB.z;
            pointB.z = t;
        }
        if (pointA.x > pointB.x)
        {
            float t;
            t = pointA.x; // swap pointA.x and pointB.x
            pointA.x = pointB.x;
            pointB.x = t;
            t = pointA.z; // swap pointA.z and pointB.z
            pointA.z = pointB.z;
            pointB.z = t;
        }
        float dx = pointB.x - pointA.x;
        float dy = Mathf.Abs(pointB.z - pointA.z);
        float error = dx / 2;
        float ystep = (pointA.z < pointB.z) ? 1 : -1;
        float y = pointA.z;
        for (int x = (int) pointA.x; x <= pointB.x; x++)
        {
            yield return new Vector3((steep ? y : x), 0, (steep ? x : y));
            error = error - dy;
            if (error < 0)
            {
                y += ystep;
                error += dx;
            }
        }
        yield break;
    }

    public void GenerateWall(Vector3 pointA, Vector3 pointB, Transform Holder)
    {
        var list = GetPointsOnLine(pointA, pointB);
        foreach (var val in list.ToList())
        {
            Transform newWall = Instantiate(wallPrefab, val, Quaternion.identity);
            newWall.parent = Holder;
        }
    }


    public void GenerateMapWithRotation()
    {

        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            //Destroy old tiles
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for(int x = 0; x < mapSize.x; x++)
        {
            for(int y = 0; y < mapSize.y; y++)
            {
                //Wall generation
                if (!((y == (int)(mapSize.y / 2 ) && (x == 0 || x == mapSize.x-1)) || (x == (int)(mapSize.y / 2 ) && (y == 0 ||  y == mapSize.y-1))))
                {
                    if (x == 0)
                    {
                        Transform newWall = Instantiate(wallPrefab, new Vector3(-mapSize.x / 2 + x, 0, -mapSize.y / 2 + y + 0.5f), Quaternion.Euler(Vector3.up * 90)) as Transform;
                        newWall.parent = mapHolder;
                    }
                    if (x == mapSize.x - 1)
                    {
                        Transform newWall = Instantiate(wallPrefab, new Vector3(-mapSize.x / 2 + x + 1, 0, -mapSize.y / 2 + y + 0.5f), Quaternion.Euler(Vector3.up * 90)) as Transform;
                        newWall.parent = mapHolder;
                    }
                    if (y == 0)
                    {
                        Transform newWall = Instantiate(wallPrefab, new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + y), Quaternion.Euler(Vector3.right * 1)) as Transform;
                        newWall.parent = mapHolder;
                    }
                    if (y == mapSize.y - 1)
                    {
                        Transform newWall = Instantiate(wallPrefab, new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + y + 1), Quaternion.Euler(Vector3.right * 1)) as Transform;
                        newWall.parent = mapHolder;
                    }
                }


                //Tile generation
                //Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                //Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                //newTile.localScale = Vector3.one * (1 - outlinePercent);
                //newTile.parent = mapHolder;
            }
        }
    }
}
