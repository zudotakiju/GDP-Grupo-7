using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesPrefabs;
    [SerializeField] private Transform ObstacleParent;
    public float obstaclesSpawnTime = 2f;
    public float obstacleSpeed = 1f;
    private float timeUntilObstacleSpawn;


    private float timer;

    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop();
        }
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstaclesSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }
    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        spawnedObstacle.transform.parent = ObstacleParent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();

        obstacleRB.linearVelocity = Vector2.left * obstacleSpeed;
    }
}
