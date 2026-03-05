using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelNumber;           // Assign in Inspector
    public Button button;             // Assign the button component
    public GameObject lockIcon;       // Assign the lock icon object
    public Color lockedColor = Color.gray; // Color when locked
    public Color unlockedColor = Color.white; // Color when unlocked
    void Start()
    {
        bool unlocked = LevelManager.instance.IsLevelUnlocked(levelNumber);

        // Set interactable
        button.interactable = unlocked;

        // Set lock icon
        if (lockIcon != null)
            lockIcon.SetActive(!unlocked);

        // Set button color
        ColorBlock cb = button.colors;
        cb.normalColor = unlocked ? unlockedColor : lockedColor;
        cb.highlightedColor = unlocked ? unlockedColor : lockedColor;
        cb.pressedColor = unlocked ? unlockedColor : lockedColor;
        button.colors = cb;
    }
}