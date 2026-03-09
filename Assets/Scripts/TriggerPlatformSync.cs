 using System.Numerics;
using UnityEngine;

public class TriggerPlatformSync : MonoBehaviour
{
    [SerializeField] Transform Trigger;
    [SerializeField] Transform platform;
    public GameObject Player;
    private UnityEngine.Vector3 platformVelocity;    
    
    private void OnTriggerStay(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.localScale = new UnityEngine.Vector3(1/platform.localScale.x, 1/platform.localScale.y, 1/platform.localScale.z);
            Player.transform.SetParent(platform, true);
        }
    }
    private void OnTriggerExit(Collider other)    
    {
        if (other.CompareTag("Player"))
        {            
            Player.transform.localScale = new UnityEngine.Vector3(1/platform.localScale.x, 1/platform.localScale.y, 1/platform.localScale.z);
            Player.transform.SetParent(null, true);
        }
    }
    private void OnTriggerEnter(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            Trigger.parent = platform;
        }
    }
}
