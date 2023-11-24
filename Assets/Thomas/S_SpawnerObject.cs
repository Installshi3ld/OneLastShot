using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnerObject : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject Player;
    public GameObject SpawnPoint;

    private GameObject tmpObjectSpawned;
    private void OnTriggerEnter(Collider other)
    {
        print("tfgujh");
        tmpObjectSpawned = Instantiate(ObjectToSpawn);
        //tmpObjectSpawned.transform.parent = Player.transform;
    }
}
