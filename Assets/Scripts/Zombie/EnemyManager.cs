using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float spawnRate;
    public List<EnemySpawner> spawners;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(OnSpawn), 2f, spawnRate);
    }

    public void OnSpawn()
    {
        spawners[Random.Range(0, spawners.Count)].SpawnZombie(enemyPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
