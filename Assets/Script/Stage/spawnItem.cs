using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItem : MonoBehaviour
{
    public GameObject[] objSpawnItemPoint;
    public GameObject[] objSpawnItem;

    private void Start()
    {
        for (int i = 0; i < objSpawnItemPoint.Length; i++)
        {
            int a = Random.Range(0, objSpawnItem.Length);
            Instantiate(objSpawnItem[a], objSpawnItemPoint[i].transform.position, Quaternion.identity);
        }
    }

}
