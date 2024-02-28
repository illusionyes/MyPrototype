using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float xRange;
    private void Start()
    {
        InvokeRepeating("SpawnPrefab",1f,1.5f);
    }
    private void SpawnPrefab()
    {
        var position = gameObject.transform.position;
        var spawnPos = new Vector3(RandomX(), position.y, position.z);
        Instantiate(enemyPrefab, spawnPos , enemyPrefab.transform.rotation);
    }
    private float RandomX()
    {
        return Random.Range(-xRange, xRange);
    }
}
