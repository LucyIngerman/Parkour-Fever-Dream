using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public GameObject winScreen;
    public TimerScript timerScript;

    void Start()
    {
        winScreen.SetActive(false); // hide at start
    }

    public void ShowWinScreen()
    {
        Time.timeScale = 0f;
        timerScript.timerTexts[0].text = "Time: " + timerScript.timerTexts[0].text;

        if(PlayerPrefs.HasKey("Level" + SceneManager.GetActiveScene().buildIndex))
        {
            float previousTime = PlayerPrefs.GetFloat("Level" + SceneManager.GetActiveScene().buildIndex);
            if(timerScript.time < previousTime)
            {
                PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex, timerScript.time);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("Level" + SceneManager.GetActiveScene().buildIndex, timerScript.time); 
        }

        winScreen.SetActive(true);
        LevelManager.instance.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelector()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelector"); // main menu scene index
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // main menu scene index
    }
}
