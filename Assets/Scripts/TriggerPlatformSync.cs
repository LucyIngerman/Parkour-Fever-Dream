using System.Numerics;
using UnityEngine;

public class TriggerPlatformSync : MonoBehaviour
{
    [SerializeField] Transform Trigger;
    public CharacterController characterController;
    private UnityEngine.Vector3 platformVelocity;
    private void OnTriggerStay(Collider other)    
    {
        if (other.CompareTag("Player"))
        {
            platformVelocity = Trigger.GetComponent<MoveTrigger>().Velocity;
            characterController.Move(platformVelocity * Time.deltaTime);
        }
    }
}
