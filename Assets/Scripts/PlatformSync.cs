using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovePlatformSync : MonoBehaviour
{
    [SerializeField] Transform platform;
    public GameObject Player;
    private void OnTriggerEnter(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            Vector3 worldScale = Vector3.one;

            other.transform.SetParent(transform);

            // Restore world scale after parenting
            other.transform.localScale = new Vector3(
                worldScale.x / transform.lossyScale.x,
                worldScale.y / transform.lossyScale.y,
                worldScale.z / transform.lossyScale.z
            );
        }
    }

    private void OnTriggerExit(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            Vector3 worldScale = Vector3.one;

            other.transform.SetParent(null);

            other.transform.localScale = worldScale;
        }
    }
}
