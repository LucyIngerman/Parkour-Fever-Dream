using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensetivity = 0.1f;
    [SerializeField] private float upDownLookRange = 80f;
    [SerializeField] private int fov = 80;
    [SerializeField] private float sensitivityMultiplier = 1.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityMultiplier = 1.0f;

    [Header("Dash Parameters")]
    [SerializeField] private float dashForce = 8.0f;
    [SerializeField] private float dashCooldown = 1.5f;
    [SerializeField] private float dashGroundedCooldown = 0.5f;

    [Header("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerInputHandler playerInputHandler;
    [SerializeField] private SettingsManager settingsManager;


    private float verticalVelocity;
    private Vector3 dashVelocity;
    private float verticalRotation;
    public bool canDash = true;
    private float dashCooldownTimer = 0f;
    private bool inputReady = false;



    private float CurrentSpeed =>
        walkSpeed * (playerInputHandler.SprintTriggered ? sprintMultiplier : 1f);

    void Start()
    {
        mainCamera.fieldOfView = fov;
        if(settingsManager != null)
        {
            mainCamera.fieldOfView = settingsManager.GetSetting("FOV", fov);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        canDash = true;

        // Delay input for one frame
        Invoke(nameof(EnableInput), 0.1f);
    }

    private void EnableInput()
    {
        inputReady = true;
    }
    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleDashCooldown();
    }

    // =========================
    // MOVEMENT
    // =========================

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();
        Vector3 horizontalMove = worldDirection * CurrentSpeed;

        // ---- GROUND CHECK ----
        if (characterController.isGrounded)
        {
            if (verticalVelocity < 0)
                verticalVelocity = -2f;

            if (playerInputHandler.JumpTriggered)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            // If player releases jump early, increase gravity
            if (!playerInputHandler.JumpTriggered && verticalVelocity > 0)
            {
                verticalVelocity += Physics.gravity.y * gravityMultiplier * 2f * Time.deltaTime; // extra gravity
            }
            else
            {
                // Normal gravity
                verticalVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
            }
        }

        HandleDashing();

        Vector3 finalMove =
            horizontalMove +
            dashVelocity +
            Vector3.up * verticalVelocity;

        characterController.Move(finalMove * Time.deltaTime);

        // Gradually reduce dash over time
        dashVelocity = Vector3.Lerp(dashVelocity, Vector3.zero, 8f * Time.deltaTime);
    }

    private Vector3 CalculateWorldDirection()
    {
        Vector3 inputDirection = new Vector3(
            playerInputHandler.MovementInput.x,
            0f,
            playerInputHandler.MovementInput.y
        );

        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    // =========================
    // DASH
    // =========================

    private void HandleDashing()
    {
        if (playerInputHandler.DashTriggered && canDash)
        {
            canDash = false;
            dashCooldownTimer = dashCooldown;

            dashVelocity = mainCamera.transform.forward.normalized * dashForce;
        }
    }

    private void HandleDashCooldown()
    {
        if (!canDash)
        {
            dashCooldownTimer -= Time.deltaTime;

            if (dashCooldownTimer <= 0f || (characterController.isGrounded && dashCooldownTimer <= dashCooldown - dashGroundedCooldown))
            {
                dashCooldownTimer = 0f;
                canDash = true;
            }
        }
    }

    // =========================
    // LOOK
    // =========================

    private void HandleRotation()
    {
        float mouseX = playerInputHandler.RotationInput.x * mouseSensetivity * sensitivityMultiplier;
        float mouseY = playerInputHandler.RotationInput.y * mouseSensetivity * sensitivityMultiplier;

        // Horizontal rotation
        transform.Rotate(0f, mouseX, 0f);

        // Vertical rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownLookRange, upDownLookRange);

        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }




}