using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

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

    public void ChangeSetting(string setting, int value)
    {
        PlayerPrefs.SetInt(setting, value);
        PlayerPrefs.Save();
    
    }

    public int GetSetting(string setting, int DefaultValue = 50)
    {
        int settingValue = PlayerPrefs.GetInt(setting, DefaultValue);
        return settingValue;
    }
}
