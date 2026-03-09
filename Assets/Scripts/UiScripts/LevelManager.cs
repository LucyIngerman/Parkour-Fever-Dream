using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockLevel(int level)
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (level > unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", level);
            PlayerPrefs.Save();
        }
    }

    public bool IsLevelUnlocked(int level)
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
        return level <= unlocked;
    }
}
