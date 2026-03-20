using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
    }
    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }

}
