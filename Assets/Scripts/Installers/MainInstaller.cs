using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private ModelRepository _modelRepository;

        public override void InstallBindings()
        {
            Container.BindInstance(_modelRepository).AsSingle();
        }
    }
}