using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public Vector2 spawnAreaSize = new Vector2(20f, 10f);

    public int poolsize = 10;
    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
            objectPool.Add(enemy);
        }
    }
    /*
    public GameObject GetEnemy()
    {
        foreach(GameObject enemy in objectPool)
        {

        }
    }*/

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetSpawnPosition();
        
    }

    Vector3 GetSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        spawnPosition = new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f), Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f), 0f);
        if(Mathf.Abs(spawnPosition.x) < spawnAreaSize.x / 2f)
        {
            if(spawnPosition.x > 0f)
            {
                spawnPosition.x += 10f;
            }

            else
            {
                spawnPosition.x -= 10f;
            }
        }
        return spawnPosition;
    }
}
