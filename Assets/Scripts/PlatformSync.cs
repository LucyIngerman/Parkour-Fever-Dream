using UnityEngine;

public class PlatformSync : MonoBehaviour
{
    [SerializeField] Transform platform;
    public CharacterController characterController;
    private void OnTriggerStay(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            characterController.Move(platform.GetComponent<MovePlatform>().Velocity * Time.deltaTime);
        }
    }
}
