using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private Transform spawnPoint;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        if (obstacles.Length == 0) return;

        int index = Random.Range(0, obstacles.Length);

        if (obstacles[index] == null) return;

        Instantiate(obstacles[index], spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawnando obstáculo");
    }
}
