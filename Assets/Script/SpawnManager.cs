using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] Birds;
    int i,a;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        

        i = Random.Range(0, 6);
        a = Random.Range(0, 3);
        Instantiate(Birds[a], spawnPoints[i].position,spawnPoints[i].rotation );
        yield return new WaitForSeconds(4);
        StartCoroutine(StartSpawning());
    }

}
