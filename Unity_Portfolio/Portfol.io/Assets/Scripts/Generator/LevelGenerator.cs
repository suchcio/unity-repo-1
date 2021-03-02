using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int mapSizeY = 100;
    public int mapSizeX = 100;

    public Vector3 startPos;

    public GameObject[] objects;
    public GameObject[,] map;

    public int runGeneratorTimes = 1;
    SpawnCondition spawnCondition = null;

    private TerrainDetector terrainDetector;

    public void SpawnObject(GameObject obj, Vector3 location)
    {
        int x = (int)location.x;
        int y = (int)location.z;
        map[x, y] = Instantiate(obj, location + startPos, Quaternion.identity, transform);
    }

    public bool IsGrass(Vector3 pos){

        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(pos + startPos, 1, 0.1f);
        switch (terrainTextureIndex)
        {
            case 0:
                return true;
            case 1:
            default:
                return false;
        }
    }

    public bool FieldIsDenied(int range, Vector3 current)
    {
        //Check if its placeable
        if (!IsGrass(current))
        {
            return true;
        }

        //Check if field has object on it
        if (map[(int)current.x, (int)current.z] != null)
            return true;
        for(int x = -range; x < range; x++)
        {
            for (int y = -range; y < range; y++)
            {
                //Check if field is denied by any of the blocked objects.
                for (int i = 0; i < spawnCondition.deny.Length; i++)
                {
                    int checkX = x + (int)current.x;
                    int checkY = y + (int)current.z;
                    if (checkX >= 0 && checkY >= 0 && checkX < mapSizeX && checkY < mapSizeY && map[checkX,checkY] != null)
                    {
                        //Temporary
                        if (map[checkX, checkY].name.Contains(spawnCondition.deny[i].name))
                        {
                            //Debug.Log($"There is {spawnCondition.deny[i].name} on {checkX}, {checkY}  ( {map[checkX,checkY].GetType()} )");
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public bool FieldIsAccepted(int range, Vector3 current)
    {
        if (spawnCondition.accept.Length == 0)
            return true;

        if (map[(int)current.x, (int)current.z] != null)
            return false;

        for (int x = -range; x < range; x++)
        {
            for (int y = -range; y < range; y++)
            {
                
                for (int i = 0; i < spawnCondition.accept.Length; i++)
                {
                    int checkX = x + (int)current.x;
                    int checkY = y + (int)current.z;
                    if (checkX >= 0 && checkY >= 0 && checkX < mapSizeX && checkY < mapSizeY && map[checkX, checkY] != null)
                    {
                        //Temporary
                        if (map[checkX, checkY].name.Contains(spawnCondition.accept[i].name))
                        {
                            //Debug.Log($"There is {spawnCondition.deny[i].name} on {checkX}, {checkY}  ( {map[checkX,checkY].GetType()} )");
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }


    Vector3 RandomisePos()
    {
        return new Vector3(Random.Range(0, 99), 0, Random.Range(0,99));
    }

    public void SpawnAllObjects()
    {
        foreach(var obj in objects)
        {
            spawnCondition = obj.GetComponent<SpawnCondition>();
            bool isDenied = true;
            bool isAccepted = false;
            int denyAttempt = 0, acceptAttempt = 0;
            Vector3 desiredPosition = new Vector3();

            //Check priority spawn for X times. Only on first iteration.
            while (acceptAttempt < spawnCondition.acceptRetry)
            {
                desiredPosition = RandomisePos();
                isAccepted = FieldIsAccepted(spawnCondition.acceptRange, desiredPosition);
                isDenied = FieldIsDenied(spawnCondition.denyRange, desiredPosition);

                //If field passed
                if (isAccepted && !isDenied)
                {
                    acceptAttempt = spawnCondition.acceptRetry;
                }
                else
                { 
                    desiredPosition = RandomisePos();
                    acceptAttempt++;
                    isDenied = true;
                    isAccepted = false;
                }
            }

            //If priority spawn failed
            //true && 0 , [1] denied, 1, [2] denied, 2, [3] denied, 3
            while (isDenied && denyAttempt != spawnCondition.denyRetry)
            {
                desiredPosition = RandomisePos();
                isDenied = FieldIsDenied(spawnCondition.denyRange, desiredPosition);
                if (isDenied)
                    denyAttempt++;
            }

            if (!isDenied)
                SpawnObject(obj, desiredPosition);
            //else
                //Debug.Log($"Couldn't spawn {obj.name}!");
        }
    }

    void Start()
    {
        terrainDetector = new TerrainDetector(true);
        map = new GameObject[mapSizeX, mapSizeY];

        for(int i = 0; i < runGeneratorTimes; i++)
            SpawnAllObjects();
    }

}
