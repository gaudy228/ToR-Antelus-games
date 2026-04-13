using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions _playerInput;

    private FirstPersonController _controllable;

    private void Awake()
    {
        _playerInput = new PlayerInputActions();

        _controllable = GetComponent<FirstPersonController>();

        _playerInput.Player.Enable();
        _playerInput.UI.Disable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.UI.Disable();
    }

    private void Update()
    {
        ReadMovement();
        ReadLook();
    }

    private void SwitchToPlayer()
    {
        _playerInput.Player.Enable();
        _playerInput.UI.Disable();
    }

    private void SwithToUI()
    {
        _playerInput.Disable();
        _playerInput.UI.Enable();
    }

    private void ReadMovement()
    {
        Vector2 inputDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        _controllable.Move(inputDirection);
    }

    private void ReadLook()
    {
        Vector2 inputDirection = _playerInput.Player.Look.ReadValue<Vector2>();

        _controllable.CameraRotate(inputDirection);
    }
}
