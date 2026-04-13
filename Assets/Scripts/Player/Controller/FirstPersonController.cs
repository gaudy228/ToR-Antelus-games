using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    private const float _maxRotationAngleX = 90f;

    private const float _minRotationAngleX = -90f;

    [SerializeField] private float _speed;

    [SerializeField] private float _mouseSensitivity;

    [SerializeField] private Camera _playerCamera;

    [SerializeField] private CharacterController _characterController;

    private float rotationX = 0f;

    public void Move(Vector2 direction)
    {
        Vector3 move = transform.right * direction.x + transform.forward * direction.y;

        _characterController.Move(move * _speed * Time.deltaTime);
    }

    public void CameraRotate(Vector2 direction)
    {
        Vector2 lookingDirection = new Vector2(direction.x, direction.y) * _mouseSensitivity;

        transform.Rotate(0, lookingDirection.x, 0);

        rotationX -= lookingDirection.y;
        rotationX = Mathf.Clamp(rotationX, _minRotationAngleX, _maxRotationAngleX);

        _playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
