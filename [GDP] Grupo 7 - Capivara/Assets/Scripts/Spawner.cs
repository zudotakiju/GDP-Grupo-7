using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Obstáculos")]
    [SerializeField] private GameObject[] groundObstacles;
    [SerializeField] private GameObject[] airObstacles;

    [Header("Spawn Points")]
    [SerializeField] private Transform groundSpawnPoint;
    [SerializeField] private Transform airSpawnPoint;

    [SerializeField] private float spawnTime = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        int type = Random.Range(0, 2);

        GameObject prefab = null;
        Vector3 pos = Vector3.zero;

        if (type == 0 && groundObstacles.Length > 0)
        {
            prefab = groundObstacles[Random.Range(0, groundObstacles.Length)];
            pos = groundSpawnPoint.position;
        }
        else if (type == 1 && airObstacles.Length > 0)
        {
            prefab = airObstacles[Random.Range(0, airObstacles.Length)];
            pos = airSpawnPoint.position;
        }

        if (prefab != null)
        {
            Instantiate(prefab, pos, Quaternion.identity); // cria um novo prefab
        }
    }
}
