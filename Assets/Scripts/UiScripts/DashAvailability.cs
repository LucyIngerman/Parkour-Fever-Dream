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
        dashImage.enabled = canDash;
    }
}