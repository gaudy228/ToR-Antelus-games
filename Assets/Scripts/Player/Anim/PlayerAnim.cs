using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private PlayerInteract _playerInteract;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _playerInteract.OnOpenDoor += OpenDoor;
    }

    private void OnDisable()
    {
        _playerInteract.OnOpenDoor -= OpenDoor;
    }

    private void OpenDoor()
    {
        _animator.SetTrigger("OpenDoor");
    }
}
