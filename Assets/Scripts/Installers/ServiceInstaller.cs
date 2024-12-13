using Services;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private ModelService _modelService;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MaterialService>().AsSingle();
            Container.BindInterfacesAndSelfTo<AnimationService>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ModelService>()
                .FromInstance(_modelService).AsSingle();
        }
    }
}