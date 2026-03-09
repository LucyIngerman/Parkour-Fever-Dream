using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelNumber;           // Assign in Inspector
    public Button button;             // Assign the button component
    public GameObject lockIcon;       // Assign the lock icon object
    public GameObject[] ObjectsToHide;
    public Color lockedColor = Color.black; // Color when locked
    public Color unlockedColor = Color.white; // Color when unlocked
    void Start()
    {
        bool unlocked = LevelManager.instance.IsLevelUnlocked(levelNumber);

        // Set interactable
        button.interactable = unlocked;

        lockIcon.SetActive(!unlocked);

        // Set button color
        ColorBlock cb = button.colors;
        cb.normalColor = unlocked ? unlockedColor : lockedColor;
        cb.highlightedColor = new Color(1f, 1f, 1f, 0.6f);
        cb.pressedColor = unlocked ? unlockedColor : lockedColor;
        button.colors = cb;
        foreach (GameObject obj in ObjectsToHide)
        {
            obj.SetActive(unlocked);
        }
    }
}