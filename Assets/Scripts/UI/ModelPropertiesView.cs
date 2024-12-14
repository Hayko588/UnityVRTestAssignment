using System.Linq;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using UniRx.Triggers;

namespace UI
{
    public class ModelPropertiesView : MonoBehaviour
    {
        [SerializeField] private Slider _colorSlider;
        [SerializeField] private Image _fill;
        [SerializeField] private TMP_Dropdown _animationsDropdown;
        [SerializeField] private Toggle _animationToggle;

        [Inject] private IUIService _uiService;
        [Inject] private IModelService _modelService;

        private Color _selectedColor = Color.white;

        private void Awake()
        {
            _colorSlider
                .OnValueChangedAsObservable()
                .Subscribe(value =>
                {
                    _selectedColor = Color.HSVToRGB(value, 1, 1);
                    _fill.color = _selectedColor;
                    _uiService.SelectColor(_selectedColor);
                })
                .AddTo(this);

            _uiService
                .OnModelSelected
                .Subscribe(model =>
                {
                    _animationsDropdown.ClearOptions();
                    var options = model
                        .Animations
                        .Select(a => a.name)
                        .ToList();
                    _animationsDropdown.AddOptions(options);
                })
                .AddTo(this);

            _modelService
                .CurrentModel
                .Subscribe(model =>
                {
                    _selectedColor = model.GetBaseColor();
                    Color.RGBToHSV(_selectedColor, out float H, out float S, out float V);
                    _colorSlider.value = H;
                })
                .AddTo(this);

            _animationsDropdown
                .OnSelectAsObservable()
                .Subscribe(_ =>
                {
                    _uiService.SelectAnimation(_animationsDropdown.options[_animationsDropdown.value].text);
                })
                .AddTo(this);

            _animationToggle
                .OnValueChangedAsObservable()
                .Subscribe(_uiService.PlayAnimation)
                .AddTo(this);
        }
    }
}