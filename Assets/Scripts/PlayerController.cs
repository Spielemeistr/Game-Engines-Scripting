using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController _CharacterController;

    [SerializeField] private Camera _Camera;

    private InputAction _move, _look, _jump;

    [SerializeField] private float MovementSpeed = 10f, RotationSpeed = 5f, Gravity = -30f, JumpForce = 20;

    private float RotationY;
    private float RotationX;
    private float VerticalVelocity;

    public float speed = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _move = InputSystem.actions.FindAction("Move");
        _look = InputSystem.actions.FindAction("Look");
        _jump = InputSystem.actions.FindAction("Jump");

        _jump.performed += Jump;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move(_move.ReadValue<Vector2>());
        Rotate(_look.ReadValue<Vector2>());
    }

    void Move(Vector2 movementVector)
    {
        Vector3 direction = transform.forward * movementVector.y + transform.right * movementVector.x;
        direction *= (MovementSpeed * Time.unscaledDeltaTime);
        _CharacterController.Move(direction);
        speed = direction.magnitude;

        VerticalVelocity = VerticalVelocity + Gravity * Time.unscaledDeltaTime;
        _CharacterController.Move(new Vector3(0,VerticalVelocity,0) * Time.unscaledDeltaTime);
    }

    void Rotate(Vector2 rotationVector)
    {
        //RotationY += (rotationVector.x * RotationSpeed);

        transform.Rotate(Vector3.up, rotationVector.x * RotationSpeed);
        
        RotationX -= (rotationVector.y * RotationSpeed);
        RotationX = Math.Clamp(RotationX, -40, 60);

        _Camera.transform.localRotation = Quaternion.Euler(RotationX, 0, 0);
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (_CharacterController.isGrounded)
        {
            VerticalVelocity = JumpForce;
        }
    }
}
