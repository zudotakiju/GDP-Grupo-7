using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float currentScore = 0f;

    public bool isPlaying = false;

    [Header("Velocidade")]
    public float gameSpeed = 5f;
    public float speedIncrease = 0.1f;

    void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
            // aumenta dificuldade com o tempo
            gameSpeed += speedIncrease * Time.deltaTime;
        }

        // alterar
        if (Input.GetKeyDown("k"))
        {
            isPlaying = true;
        }

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
        currentScore = 0;
        isPlaying = false;
    }
}
