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
        IReadOnlyReactiveProperty<string> OnAnimationSelected { get; }
        IReadOnlyReactiveProperty<bool> OnAnimationPlay { get; }
        
        void SelectModel(ModelConfig modelConfig);
        void SelectColor(Color color);
        void SelectAnimation(string clipName);
        void PlayAnimation(bool play);
    }

    public class UIService : IUIService
    {
        private Subject<ModelConfig> _modelSelectedSubject = new();
        private Subject<Color> _colorSelectedSubject = new();
        private Subject<string> _animationSelectedSubject = new();
        private Subject<bool> _animationPlaySubject = new();

        public IReadOnlyReactiveProperty<ModelConfig> OnModelSelected => _modelSelectedSubject.ToReactiveProperty();
        public IReadOnlyReactiveProperty<Color> OnColorSelected => _colorSelectedSubject.ToReactiveProperty();

        public IReadOnlyReactiveProperty<string> OnAnimationSelected =>
            _animationSelectedSubject.ToReactiveProperty();

        public IReadOnlyReactiveProperty<bool> OnAnimationPlay =>
            _animationPlaySubject.ToReactiveProperty();


        public void SelectModel(ModelConfig modelConfig)
        {
            _modelSelectedSubject?.OnNext(modelConfig);
        }

        public void SelectColor(Color color)
        {
            _colorSelectedSubject?.OnNext(color);
        }

        public void SelectAnimation(string clipName)
        {
            _animationSelectedSubject?.OnNext(clipName);
        }

        public void PlayAnimation(bool play)
        {
            _animationPlaySubject?.OnNext(play);
        }
    }
}