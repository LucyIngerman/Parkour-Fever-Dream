using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public TextMeshProUGUI[] HighScoreTexts;
    void Start()
    {
        for (int i = 0; i < HighScoreTexts.Length; i++)
        {
            float highScore = PlayerPrefs.GetFloat("Level" + (i + 1), 0);
            int minutes = (int)highScore / 60;
            int seconds = (int)highScore % 60;
            int milliseconds = (int)(highScore % 1 * 100);
            if (highScore == 0)
            {
                HighScoreTexts[i].text = "Not Completed";
            }
            else
            {
                HighScoreTexts[i].text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
            }
        }
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }   
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}