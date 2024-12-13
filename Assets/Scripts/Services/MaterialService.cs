using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services
{
    public interface IMaterialService
    {
        void ChangeColor(Color color);
    }

    public class MaterialService : MonoBehaviour, IMaterialService
    {
        private IUIService _uiService;
        private IModelService _modelService;

        private ModelExhibit _currentModel;

        [Inject]
        public void Construct(IUIService uiService, IModelService modelService)
        {
            _uiService = uiService;
            _modelService = modelService;
        }

        private void Start()
        {
            _modelService
                .OnModelChanged
                .Subscribe(SetModel)
                .AddTo(this);

            _uiService
                .OnColorSelected
                .Subscribe(ChangeColor)
                .AddTo(this);
        }

        private void SetModel(ModelExhibit modelExhibit)
        {
            _currentModel = modelExhibit;
        }

        public void ChangeColor(Color color)
        {
            _currentModel.SetBaseColor(color);
        }
    }
}