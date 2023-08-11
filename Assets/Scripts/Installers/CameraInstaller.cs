using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private Camera _cameraPrefab;
    [SerializeField] private Transform _spawnCameraPoint;
    
    public override void InstallBindings()
    {
        BindCamera();
    }

    private void BindCamera()
    {
        Container
            .Bind<CameraController>()
            .FromComponentInNewPrefab(_cameraPrefab)
            .UnderTransform(_spawnCameraPoint)
            .AsSingle()
            .NonLazy();
    }
}