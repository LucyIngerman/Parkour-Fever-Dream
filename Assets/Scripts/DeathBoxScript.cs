using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public DeathScreenManager deathScreenManager;
    public Transform respawnPoint; // where the player will respawn
    public bool instantKill = true; // set to false if you want custom effect

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (instantKill)
            {   
                deathScreenManager.ShowDeathScreen();
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
}
