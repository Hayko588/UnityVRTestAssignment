using System;
using System.Collections.Generic;
using TMPro;
using UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

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

    public class UIService : MonoBehaviour, IUIService
    {
        [SerializeField] private ModelSelectionView _modelSelectionView;
        [SerializeField] private GameObject colorPickerMenu;
        [SerializeField] private GameObject animationMenu;

        [SerializeField] private Button colorPickerButton;
        [SerializeField] private TMP_Dropdown modelDropdown;
        [SerializeField] private TMP_Dropdown animationDropdown;
        [SerializeField] private TMP_InputField colorInputField;

        private readonly Subject<int> _modelSelectedSubject = new Subject<int>();
        private readonly Subject<Color> _colorSelectedSubject = new Subject<Color>();
        private readonly Subject<string> _animationSelectedSubject = new Subject<string>();

        public IObservable<Color> OnColorSelected => _colorSelectedSubject;
        public IObservable<string> OnAnimationSelected => _animationSelectedSubject;

        private Subject<ModelConfig> _onModelSelected = new();
        public IReadOnlyReactiveProperty<ModelConfig> OnModelSelected => _onModelSelected.ToReactiveProperty();
        
        private void Awake()
        {
            
        }

        public void SelectModel(ModelConfig modelConfig)
        {
            _onModelSelected?.OnNext(modelConfig);
        }

        public void ShowColorPicker()
        {
            colorPickerMenu.SetActive(true);
        }

        private void OpenColorPicker()
        {
            // Логика открытия Color Picker
            Debug.Log("Color Picker Opened");
        }

        public void ShowAnimationMenu(List<string> animationNames)
        {
            animationMenu.SetActive(true);

            // Очистка и наполнение Dropdown
            animationDropdown.ClearOptions();
            animationDropdown.AddOptions(animationNames);
        }
    }
}