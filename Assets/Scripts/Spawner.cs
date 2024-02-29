using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] unitPrefab;
    [SerializeField] private GameObject unitSpawnPoint;
    [SerializeField] private float xRange;
    public static bool isOver;
    private void Awake()
    {
        isOver = false;
        var unit = unitPrefab[DataManager.Instance.heroInt];
        Instantiate(unit, unitSpawnPoint.transform.position,unit.transform.rotation);
        StartCoroutine(SpawnPrefabCoroutine());
    }
    private IEnumerator SpawnPrefabCoroutine()
    {
        while (isOver == false)
        {
            SpawnPrefab();
            yield return new WaitForSeconds(1);
        }
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
