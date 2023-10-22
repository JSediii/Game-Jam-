using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private GameObject[] enemyPrefabs;
    
    private void Start(){

        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner (){

        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(true)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length - 1);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
