using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float currentScore = 0f;

    public bool isPlaying = false;

    [Header("Velocidade")]
    public float gameSpeed = 5f;
    public float speedIncrease = 0.1f;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    void Start()
    {
        StartGame();
    }

    void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
            // aumenta dificuldade com o tempo
            gameSpeed += speedIncrease * Time.deltaTime;
        }

    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        Time.timeScale = 1f;
    }
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        currentScore = 0;
        Time.timeScale = 0f;
        isPlaying = false;
    }
}
