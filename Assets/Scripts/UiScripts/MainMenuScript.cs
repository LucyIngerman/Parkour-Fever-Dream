using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SaveeraserText;
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

    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
        SaveeraserText.SetActive(true);
    }
}