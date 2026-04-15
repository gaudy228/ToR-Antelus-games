using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour, IInteract
{
    private const float _openAngle = 90f;

    [SerializeField] private float _openSpeed;
    [SerializeField] private GameObject _doorHinge;
    [SerializeField] private GameObject _player;
    
    private bool _isOpen = false;
    private bool _isMoving = false;

    private Vector3 _startAngle;

    private void Start()
    {
        _startAngle = _doorHinge.transform.localEulerAngles;
    }

    public void Interact()
    {
        if (_isMoving)
        {
            return;
        }
        ToggleDoor().Forget();
    }

    public async UniTask ToggleDoor()
    {
        _isOpen = !_isOpen;
        _isMoving = true;

        Vector3 directionToPlayer = _player.transform.position - _doorHinge.transform.position;

        Vector3 localDir = _doorHinge.transform.InverseTransformDirection(directionToPlayer);

        float openDirection = localDir.x > 0 ? _openAngle : -_openAngle;

        Vector3 targetAngle = _isOpen ? new Vector3(0, _doorHinge.transform.localEulerAngles.y + openDirection, 0) : _startAngle;

        await _doorHinge.transform.DOLocalRotate(targetAngle, _openSpeed).AsyncWaitForCompletion();

        _isMoving = false;
    }
}
