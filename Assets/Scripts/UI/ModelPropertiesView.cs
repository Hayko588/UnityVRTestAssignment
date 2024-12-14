using System.Linq;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;

namespace UI
{
    public class ModelPropertiesView : MonoBehaviour
    {
        [SerializeField] private Slider _colorSlider;
        [SerializeField] private Image _fill;
        [SerializeField] private TMP_Dropdown _animationsDropdown;
        [SerializeField] private Toggle _animationToggle;
        [SerializeField] private Transform _animationToggleRoot;
        [SerializeField] private Transform _animationsDropdownRoot;

        [Inject] private IUIService _uiService;
        [Inject] private IModelService _modelService;

        private Color _selectedColor = Color.white;

        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            _colorSlider
                .OnValueChangedAsObservable()
                .Subscribe(OnColorValueChanged)
                .AddTo(this);

            _uiService
                .OnModelSelected
                .Subscribe(OnModelSelected)
                .AddTo(this);

            _modelService
                .CurrentModel
                .Subscribe(OnModelChanged)
                .AddTo(this);

            _animationsDropdown
                .OnSelectAsObservable()
                .Subscribe(OnAnimationSelected)
                .AddTo(this);

            _animationToggle
                .OnValueChangedAsObservable()
                .Subscribe(_uiService.PlayAnimation)
                .AddTo(this);
        }

        private void OnColorValueChanged(float value)
        {
            _selectedColor = Color.HSVToRGB(value, 1, 1);
            _fill.color = _selectedColor;
            _uiService.SelectColor(_selectedColor);
        }

        private void OnModelChanged(ModelExhibit model)
        {
            _selectedColor = model.GetBaseColor();
            Color.RGBToHSV(_selectedColor, out float H, out float S, out float V);
            _colorSlider.value = H;
        }

        private void OnAnimationSelected(BaseEventData baseEventData)
        {
            _uiService.SelectAnimation(_animationsDropdown.options[_animationsDropdown.value].text);
        }

        private void OnModelSelected(ModelConfig model)
        {
            _animationsDropdown.ClearOptions();
            bool hasAnimations = model.Animations.Count > 0;
            if (hasAnimations)
            {
                var options = model
                    .Animations
                    .Select(a => a.name)
                    .ToList();
                _animationsDropdown.AddOptions(options);
            }

            _animationsDropdownRoot.gameObject.SetActive(hasAnimations);
            _animationToggleRoot.gameObject.SetActive(hasAnimations);
        }
    }
}