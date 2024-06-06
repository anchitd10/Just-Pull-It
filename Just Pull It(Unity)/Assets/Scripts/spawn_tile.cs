using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundtile;
    //public GameObject[] objects;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundtile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    /*public void SpawnObject()
    {
        GameObject temp1 = Instantiate(groundtile, nextSpawnPoint, Quaternion.identity);
    }*/

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<15; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
