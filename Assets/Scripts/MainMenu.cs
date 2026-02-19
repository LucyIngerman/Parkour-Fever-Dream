using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelector"); 
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsMenu"); 
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}