using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCondition : MonoBehaviour
{
    public int ObjectId;
    public GameObject[] deny;
    public GameObject[] accept;
    public int denyRange = 5;
    public int denyRetry = 3;
    public int acceptRange = 5;
    public int acceptRetry = 3;

}
