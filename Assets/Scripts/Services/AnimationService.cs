using System;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services
{
    public interface IAnimationService
    {
    }

    public class AnimationService : IAnimationService, IDisposable
    {
        private IUIService _uiService;
        private IModelService _modelService;
        private Animation _currentAnimationComponent;

        private CompositeDisposable _compositeDisposable = new();

        [Inject]
        public void Construct(IUIService uiService, IModelService modelService)
        {
            _uiService = uiService;
            _modelService = modelService;

            _uiService
                .OnAnimationSelected
                .Subscribe(SetClip)
                .AddTo(_compositeDisposable);

            _uiService
                .OnAnimationPlay
                .Subscribe(PlayAnimation)
                .AddTo(_compositeDisposable);

            _modelService
                .CurrentModel
                .Skip(1)
                .Subscribe(model => { SetAnimation(model.AnimationComponent); })
                .AddTo(_compositeDisposable);
        }

        private void SetAnimation(Animation animation)
        {
            _currentAnimationComponent = animation;
        }

        private void SetClip(string clipName)
        {
            var clip = _modelService
                .CurrentModelConfig
                .Animations
                .First(a => a.name == clipName);

            _currentAnimationComponent.clip = clip;
            if (_currentAnimationComponent.isPlaying)
            {
                _currentAnimationComponent.Play();
            }
        }

        private void PlayAnimation(bool play)
        {
            if (_currentAnimationComponent)
            {
                if (play)
                    _currentAnimationComponent.Play();
                else
                    _currentAnimationComponent.Stop();
            }
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}