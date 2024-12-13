using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services
{
    public interface IModelService
    {
        GameObject LoadModel(ModelConfig modelConfig);
        Transform GetModelTransform();
    }

    public class ModelService : MonoBehaviour, IModelService
    {
        [SerializeField] private Transform _origin;

        [Inject] private IUIService _uiService;

        private int _selectedModelIndex = 0;
        private GameObject _currentModel;
        private Transform _modelTransform;

        private void Awake()
        {
            _uiService
                .OnModelSelected
                .Subscribe(model => LoadModel(model))
                .AddTo(this);
        }

        public Transform GetModelTransform() => _modelTransform;

        public GameObject LoadModel(ModelConfig modelConfig)
        {
            if (_currentModel != null)
            {
                Destroy(_currentModel);
            }

            _currentModel = Instantiate(modelConfig.Prefab, _origin.position, Quaternion.identity);
            _modelTransform = _currentModel.transform;
            return _currentModel;
        }
    }
}