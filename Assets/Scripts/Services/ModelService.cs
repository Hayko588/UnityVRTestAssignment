using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services
{
    public interface IModelService
    {
        ModelConfig CurrentModelConfig { get; }
        IReactiveProperty<ModelExhibit> CurrentModel { get; }
        void LoadModel(ModelConfig modelConfig);
    }

    public class ModelService : MonoBehaviour, IModelService
    {
        [SerializeField] private Transform _origin;

        private IUIService _uiService;

        public IReactiveProperty<ModelExhibit> CurrentModel { get; private set; } = new ReactiveProperty<ModelExhibit>();
        
        public ModelConfig CurrentModelConfig { get; private set; }
        
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
            if (CurrentModel.Value != null)
            {
                Destroy(CurrentModel.Value.gameObject);
            }

            CurrentModelConfig = modelConfig;
            CurrentModel.Value = Instantiate(modelConfig.Prefab, _origin.position, Quaternion.identity);
        }
    }
}