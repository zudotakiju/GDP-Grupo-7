using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject gameOverUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }
    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }

    public void ReplayButtonHandler()
    {
        gm.StartGame();
        gameOverUI.SetActive(false);
    }

    private void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

}
