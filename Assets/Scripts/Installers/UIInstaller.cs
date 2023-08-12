using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private UIBar _uiPrefab;
    [SerializeField] private Transform _spawnUIPoint;


    public override void InstallBindings()
    {
        BindUIBar();
    }
    
    private void BindUIBar()
    {
        Container
            .Bind<UIBar>()
            .FromComponentInNewPrefab(_uiPrefab)
            .UnderTransform(_spawnUIPoint)
            .AsSingle()
            .NonLazy();
    }
}