using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameScope : LifetimeScope
{
    [SerializeField] private PlayerInput _playerInput;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Pause>(Lifetime.Singleton);
        builder.RegisterInstance(_playerInput);
    }
}
