using UnityEngine;

public class WinBox : MonoBehaviour
{
    public WinScreenManager winScreenManager;
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.position;
            winScreenManager.ShowWinScreen();
        }
    }
}
