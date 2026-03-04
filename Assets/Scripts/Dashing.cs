using UnityEngine;

public class Dashing : MonoBehaviour
{


    [Header("Refrences")]
    public Transform orientation;
    public Transform playercam;
    private Rigidbody rb;
    // private PlayerMovement pm;


    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
