using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void DoGameOver()
    {
        this.gameObject.SetActive(true);
        PauseController.canPause = false;
        Time.timeScale = 0;
        scoreUI.text = "Score : " + HUDController.Timer.ToString("0");
    }

}
