using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private ModelService _modelService;
        [SerializeField] private MaterialService _materialService;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<UIService>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<ModelService>()
                .FromInstance(_modelService)
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<MaterialService>()
                .FromInstance(_materialService)
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<AnimationService>()
                .AsSingle();
        }
    }
}