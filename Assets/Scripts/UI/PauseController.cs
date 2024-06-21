using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public Canvas pauseMenuCanvas;
    public static bool isPaused = false;
    public static bool canPause = true;

    void Awake()
    {
        // Hide pause menu canvas at the start
        pauseMenuCanvas.enabled = false;

        // Ensure the game is not paused when the scene starts
        Time.timeScale = 1;
    }

    void Update()
    {
        if (!canPause) return;
        // Toggle pause mode when pressing the Escape key
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0;
            pauseMenuCanvas.enabled = true;
        }
        else
        {
            // Unpause the game
            Time.timeScale = 1;
            pauseMenuCanvas.enabled = false;
        }
    }

    public void ResumeGame()
    {
        // Method to resume the game from the pause menu
        isPaused = false;
        Time.timeScale = 1;
        pauseMenuCanvas.enabled = false;
    }
    void OnEnable()
    {
        // Ensure the game is not paused when this script is enabled
        Time.timeScale = 1;
    }
}
