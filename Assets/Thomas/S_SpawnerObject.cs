using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnerObject : MonoBehaviour
{
    public List<GameObject> ObjectSpawnable;
    public GameObject Player;
    public GameObject SpawnPoint;

    private GameObject tmpObjectSpawned;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(ObjectSpawnable.Count == 1)
            {
                tmpObjectSpawned = Instantiate(ObjectSpawnable[0], SpawnPoint.transform.position, Quaternion.identity);
                tmpObjectSpawned.transform.parent = Player.transform;
            }
            else
            {
                tmpObjectSpawned = Instantiate(ObjectSpawnable[Random.Range(0, ObjectSpawnable.Count)], SpawnPoint.transform.position, Quaternion.identity);
                tmpObjectSpawned.transform.parent = Player.transform;
            }
        }
    }

}
