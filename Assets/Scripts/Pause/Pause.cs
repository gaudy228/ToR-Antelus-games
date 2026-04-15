using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        _playerInput.SwithToUI();
    }

    public void GameUnPause()
    {
        Time.timeScale = 1;
        _playerInput.SwitchToPlayer();
    }
}
