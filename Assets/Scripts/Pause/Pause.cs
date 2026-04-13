using UnityEngine;
using VContainer.Unity;

public class Pause : IStartable
{
    private PlayerInput _playerInput;

    public Pause(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }

    public void Start()
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
