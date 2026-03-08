using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SliderNumberScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Slider slider;
    [SerializeField] private string settingType;
    [SerializeField] private SettingsManager settingsManager;


    private int fovNumber;

    // Update is called once per frame
    void Update()
    {
        fovNumber = Convert.ToInt32(slider.value);
        if (text.text != Convert.ToString(slider.value))
        {
            text.text = Convert.ToString(slider.value);
            settingsManager.ChangeSetting(settingType, fovNumber);
        }
    }
}
