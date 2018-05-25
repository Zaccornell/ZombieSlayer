using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {

    public GameObject zombiePrefab;
    public List<EnemyAI> zombieList = new List<EnemyAI>();
    public List<Transform> spawnPointList = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        SpawnNewZombie();
    }

  
    void SpawnNewZombie()
    {
        for (int i = 0; i < 3; i++)
        {
            Transform selectedSpawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];
            GameObject newDuck = Instantiate(zombiePrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
            zombieList.Add(newDuck.GetComponent<EnemyAI>());
        }
    }
}
