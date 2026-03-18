using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Velocidade")]
    public float gameSpeed = 5f;
    public float speedIncrease = 0.1f;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // aumenta dificuldade com o tempo
        gameSpeed += speedIncrease * Time.deltaTime;
    }
}
