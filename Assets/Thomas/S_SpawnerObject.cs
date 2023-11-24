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
        tmpObjectSpawned = Instantiate(ObjectToSpawn, SpawnPoint.transform.position, Quaternion.identity);
        tmpObjectSpawned.transform.parent = Player.transform;
    }
}
