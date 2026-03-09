using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlatformSync : MonoBehaviour
{
    [SerializeField] Transform platform;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.localScale = new UnityEngine.Vector3(1/platform.localScale.x, 1/platform.localScale.y, 1/platform.localScale.z);
            Player.transform.SetParent(platform, true);
        }
    }
    private void OnTriggerStay(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.localScale = new UnityEngine.Vector3(1/platform.localScale.x, 1/platform.localScale.y, 1/platform.localScale.z);
            float yaw = Camera.main.transform.eulerAngles.y;
            Player.transform.rotation = UnityEngine.Quaternion.Euler(0f, yaw, 0f);
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
}
