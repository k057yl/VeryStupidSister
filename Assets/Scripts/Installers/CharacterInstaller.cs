using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private CharController _charController;
    [SerializeField] private Transform _spawnCharacterPoint;
    

    public override void InstallBindings()
    {
        BindCharacter();
    }

    private void BindCharacter()
    {
        Container
            .Bind<CharController>()
            .FromComponentInNewPrefab(_charController)
            .UnderTransform(_spawnCharacterPoint)
            .AsSingle()
            .NonLazy();
    }
}