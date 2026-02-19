using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject deathScreen; // assign in inspector
    public GameObject pauseMenuUI;
    public MonoBehaviour[] scriptsToDisable; // player & camera scripts

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !deathScreen.activeSelf) // toggle pause with ESC
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f; // freeze game
        isPaused = true;

        // Disable player & camera scripts
        foreach (var script in scriptsToDisable)
            script.enabled = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPaused = false;

        // Enable player & camera scripts
        foreach (var script in scriptsToDisable)
            script.enabled = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // main menu scene index
    }
}
