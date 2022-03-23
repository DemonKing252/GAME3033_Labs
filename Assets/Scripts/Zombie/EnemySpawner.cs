using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Collider collider;
    public void SpawnZombie(GameObject go)
    {
        Vector3 loc = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), transform.position.y, Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        Instantiate(go, loc, Quaternion.identity);
    }
}
