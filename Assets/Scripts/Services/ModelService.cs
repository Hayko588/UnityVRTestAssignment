using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services
{
    public interface IModelService
    {
        IReadOnlyReactiveProperty<ModelExhibit> OnModelChanged { get; }
        void LoadModel(ModelConfig modelConfig);
    }

    public class ModelService : MonoBehaviour, IModelService
    {
        [SerializeField] private Transform _origin;

        private IUIService _uiService;

        private ReactiveProperty<ModelExhibit> _currentModel = new();
        public IReadOnlyReactiveProperty<ModelExhibit> OnModelChanged => _currentModel;

        [Inject]
        public void Construct(IUIService uiService)
        {
            _uiService = uiService;

            _uiService
                .OnModelSelected
                .Subscribe(model => LoadModel(model))
                .AddTo(this);
        }

        public void LoadModel(ModelConfig modelConfig)
        {
            if (_currentModel.Value != null)
            {
                Destroy(_currentModel.Value.gameObject);
                _currentModel.Value = null;
            }

            _currentModel.Value = Instantiate(modelConfig.Prefab, _origin.position, Quaternion.identity);
        }
    }
}