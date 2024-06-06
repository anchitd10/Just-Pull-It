//using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] Vector3 Spawnvalues;
    [SerializeField] float spawnwait;
    [SerializeField] float startwait;
    [SerializeField] float objectLifetime;
    int object_index;

    AudioManager audiomanager;

    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    //private ArrayList spawnedObjects = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
        //StartCoroutine(DestroyObjectsAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startwait);

        while (true)
        {
            object_index = Random.Range(0, objects.Length);
            Vector3 spawnPosition = new Vector3(Spawnvalues.x, Spawnvalues.y, Spawnvalues.z);
            Instantiate(objects[object_index], spawnPosition + transform.TransformPoint(0, 0, 0), Quaternion.identity /*gameObject.transform.rotation*/);
            //GameObject spawnedObject = Instantiate(objects[object_index], spawnPosition + transform.TransformPoint(0, 0, 0),Quaternion.identity /*gameObject.transform.rotation*/);
            //spawnedObjects.Add(spawnedObject);
            //Debug.Log(spawnedObjects);

            yield return new WaitForSeconds(spawnwait);
        }
    }

    /*IEnumerator DestroyObjectsAfterTime()
    {
        yield return new WaitForSeconds(objectLifetime);
        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }
    }*/
}
