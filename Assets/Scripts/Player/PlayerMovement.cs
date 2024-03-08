using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null;
    private float moveSpeed = 1.5f;
    private float sprintSpeed = 3f;
    private bool isSprinting = false;

    private void Awake()
    {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
        input.Player.Sprint.started += OnSprintStarted;
        input.Player.Sprint.canceled += OnSprintCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
        input.Player.Sprint.started -= OnSprintStarted;
        input.Player.Sprint.canceled -= OnSprintCanceled;
    }

    private void FixedUpdate()
    {
        float currentMoveSpeed = isSprinting ? sprintSpeed : moveSpeed;
        rb.velocity = moveVector * currentMoveSpeed;
    }

    public void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    public void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    public void OnSprintStarted(InputAction.CallbackContext context)
    {
        isSprinting = true;

    }

    public void OnSprintCanceled(InputAction.CallbackContext context)
    {
        isSprinting = false;

    }
}
