using System;
using System.Collections.Generic;
using TMPro;
using UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Services
{
    public interface IUIService
    {
        IReadOnlyReactiveProperty<ModelConfig> OnModelSelected { get; }
        // IObservable<Color> OnColorSelected { get; }
        // IObservable<string> OnAnimationSelected { get; }
        //
        void SelectModel(ModelConfig modelConfig);
        // void ShowColorPicker();
        // void ShowAnimationMenu(List<string> animationNames);
    }

    public class UIService : IUIService
    {
        // private readonly Subject<Color> _colorSelectedSubject = new Subject<Color>();
        // private readonly Subject<string> _animationSelectedSubject = new Subject<string>();

        private Subject<ModelConfig> _onModelSelected = new();
        public IReadOnlyReactiveProperty<ModelConfig> OnModelSelected => _onModelSelected.ToReactiveProperty();
        
        private void Awake()
        {
            
        }

        public void SelectModel(ModelConfig modelConfig)
        {
            _onModelSelected?.OnNext(modelConfig);
        }
    }
}