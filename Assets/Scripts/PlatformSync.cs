using UnityEngine;

public class PlatformSync : MonoBehaviour
{
    [SerializeField] string playertag = "Player";
    [SerializeField] Transform platform;
    private void OnTriggerEnter(Collider other)    
    {
        if (other.CompareTag(playertag))
        {
            other.transform.SetParent(platform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playertag))
        {
            other.transform.SetParent(null);
        }
    }
}
