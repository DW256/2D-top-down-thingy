using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPaused { get; private set; } = false;
    public bool canPause { get; private set; } = true;


    [SerializeField] private Canvas PauseCanvas;
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private TextMeshProUGUI scoreUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        Play();
    }

    private void Update()
    {
        if (!canPause) return;
        // Toggle pause mode when pressing the Escape key | aing mager wkwk 
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Play();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Play()
    {
        Time.timeScale = 1.0f;
        canPause = true;
        isPaused = false;
        PauseCanvas.gameObject.SetActive(false);
        GameOverCanvas.gameObject.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        canPause = true;
        isPaused = true;
        PauseCanvas.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        canPause = false;
        isPaused = true;
        GameOverCanvas.gameObject.SetActive(true);
        scoreUI.text = "Score : " + HUDController.Timer.ToString("0");
    }
}
