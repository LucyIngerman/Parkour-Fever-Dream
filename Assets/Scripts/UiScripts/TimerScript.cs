using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI[] timerTexts;
    public PauseMenuManager pauseMenuScreen;
    public float time { get; private set; }

    void Update()
    {
        if (!pauseMenuScreen.isActiveAndEnabled)
        {
            time += Time.deltaTime;
        }

        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);

        if(Time.timeScale != 0)
        {
            for (int i = 0; i < timerTexts.Length; i++)
            {
                timerTexts[i].text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
            }
        }
        else
        {
            for (int i = 0; i < timerTexts.Length; i++)
            {
                timerTexts[i].text = string.Format("Time: {0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
            }
        }
    }
}