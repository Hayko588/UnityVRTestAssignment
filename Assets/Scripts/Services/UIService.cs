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
        IReadOnlyReactiveProperty<Color> OnColorSelected { get; }

        // IObservable<string> OnAnimationSelected { get; }
        
        void SelectModel(ModelConfig modelConfig);
        void SelectColor(Color color);
        // void ShowAnimationMenu(List<string> animationNames);
    }

    public class UIService : IUIService
    {
        // private readonly Subject<Color> _colorSelectedSubject = new Subject<Color>();
        // private readonly Subject<string> _animationSelectedSubject = new Subject<string>();

        private Subject<ModelConfig> _modelSelectedSubject = new();
        private Subject<Color> _colorSelectedSubject = new();

        public IReadOnlyReactiveProperty<ModelConfig> OnModelSelected => _modelSelectedSubject.ToReactiveProperty();
        public IReadOnlyReactiveProperty<Color> OnColorSelected => _colorSelectedSubject.ToReactiveProperty();
        

        public void SelectModel(ModelConfig modelConfig)
        {
            _modelSelectedSubject?.OnNext(modelConfig);
        }

        public void SelectColor(Color color)
        {
            _colorSelectedSubject?.OnNext(color);
        }
    }
}