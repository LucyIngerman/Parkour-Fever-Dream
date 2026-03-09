using UnityEngine;
using UnityEngine.UI;

public class DashAvailability : MonoBehaviour
{
    [SerializeField] private FirstPersonController firstPersonController;
    private Image dashImage;

    void Start()
    {
        dashImage = GetComponent<Image>();
    }

    void Update()
    {
        bool canDash = firstPersonController.canDash;
        dashImage.color = canDash ? Color.white : new Color(1f, 1f, 1f, 0.3f); // full opacity if can dash, half if not
    }
}