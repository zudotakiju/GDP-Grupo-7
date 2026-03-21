using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float currentScore = 0f;

    public Data data;

    public bool isPlaying = false;

    [Header("Velocidade")]
    public float gameSpeed = 5f;
    public float speedIncrease = 0.1f;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    void Start()
    {
        string loadedData = SaveSystem.Load("save");
        if (loadedData != null)
        {
            data = JsonUtility.FromJson<Data>(loadedData);
        }
        else
        {
            data = new Data();
        }
        StartGame();
    }

    void Update()
    {

        if (!PauseMenu.isPaused)
        {
            if (isPlaying)
            {
                currentScore += Time.deltaTime;
                // aumenta dificuldade com o tempo
                gameSpeed += speedIncrease * Time.deltaTime;
            }
        }

    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        Time.timeScale = 1f;
        currentScore = 0;
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

    public string PrettyHighscore()
    {
        return Mathf.RoundToInt(data.highscore).ToString();
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        if (data.highscore < currentScore)
        {
            data.highscore = currentScore;
            string saveString = JsonUtility.ToJson(data);
            SaveSystem.Save("save", saveString);
        }
        Time.timeScale = 0f;
        isPlaying = false;
        PauseMenu.isPaused = false;
    }
}
