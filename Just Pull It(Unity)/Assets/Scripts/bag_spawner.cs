using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class bag_spawner : MonoBehaviour
{
    public GameObject[] objects;
    [SerializeField] Vector3 Spawnvalues;
    [SerializeField] float spawnwait;
    [SerializeField] float startwait;
    [SerializeField] float objectLifetime;

    int object_index;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
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
            Vector3 spawnPosition = new Vector3(Spawnvalues.x, Random.Range(2,4), Spawnvalues.z);
            GameObject spawnedbag = Instantiate(objects[object_index], spawnPosition + transform.TransformPoint(0, 0, 0), Quaternion.identity /*gameObject.transform.rotation*/);

            //yield return new WaitForSeconds(objectLifetime);
            //Destroy(spawnedbag);

            yield return new WaitForSeconds(spawnwait);
        }
    }
}
