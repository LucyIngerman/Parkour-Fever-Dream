using UnityEngine;

public class WinBox : MonoBehaviour
{
    public WinScreenManager winScreenManager;
    public Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                winScreenManager.ShowDeathScreen();
                other.transform.position = respawnPoint.position;

                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
        }
    }
}
