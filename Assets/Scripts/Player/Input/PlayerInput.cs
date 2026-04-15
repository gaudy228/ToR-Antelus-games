using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions _playerInput;

    private FirstPersonController _controllable;

    [SerializeField] private PlayerInteract _playerInteract;

    private void Awake()
    {
        _playerInput = new PlayerInputActions();

        _controllable = GetComponent<FirstPersonController>();

        SwitchToPlayer();
    }

    private void OnEnable()
    {
        _playerInput.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        _playerInput.Player.Interact.performed -= OnInteract;
        _playerInput.Disable();
        _playerInput.TutorUI.Disable();
    }

    private void Update()
    {
        ReadMovement();
        ReadLook();
    }

    public void SwitchToPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerInput.Player.Enable();
        _playerInput.TutorUI.Disable();
    }

    public void SwithToUI()
    {
        Cursor.lockState = CursorLockMode.None;
        _playerInput.Disable();
        _playerInput.TutorUI.Enable();
    }

    private void OnInteract(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerInteract.Interact();
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
