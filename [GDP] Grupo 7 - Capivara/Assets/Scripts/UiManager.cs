using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
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

    private void ActivateGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void PlayButtonHandler()
    {
        gm.StartGame();
        //startMenuUI.SetActive(false);
    }

}
