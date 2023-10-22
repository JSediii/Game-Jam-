using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;

    public int limitSpawn = 3;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;

            // Remove destroyed enemies from the list
            spawnedEnemies.RemoveAll(enemy => enemy == null);

            if (spawnedEnemies.Count < limitSpawn)
            {
                int rand = Random.Range(0, enemyPrefabs.Length);
                GameObject enemyToSpawn = enemyPrefabs[rand];
                GameObject spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
                spawnedEnemies.Add(spawnedEnemy);
            }
        }
    }
}