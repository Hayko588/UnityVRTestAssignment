using System.Collections.Generic;
using Services;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ModelSelectionView : MonoBehaviour
    {
        [SerializeField] private ModelItemUI _modelItemUIPrefab;
        [SerializeField] private RectTransform _content;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _previousButton;

        [Inject] private ModelRepository _modelRepository;
        [Inject] private IUIService _uiService;

        private int _selectedItemIndex = 0;
        private List<ModelItemUI> _modelItems = new();

        private void Awake()
        {
            Subscribe();
            CreateModelItems();
        }

        private void Subscribe()
        {
            _nextButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (++_selectedItemIndex >= _modelItems.Count)
                    {
                        _selectedItemIndex = 0;
                    }

                    SelectModelItem(_modelItems[_selectedItemIndex]);
                })
                .AddTo(this);

            _previousButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    if (--_selectedItemIndex < 0)
                    {
                        _selectedItemIndex = _modelItems.Count - 1;
                    }

                    SelectModelItem(_modelItems[_selectedItemIndex]);
                })
                .AddTo(this);
        }

        private void CreateModelItems()
        {
            foreach (var modelConfig in _modelRepository.Models)
            {
                var modelItem = Instantiate(_modelItemUIPrefab, _content);
                modelItem.Initialize(modelConfig);
                _modelItems.Add(modelItem);
            }

            SelectModelItem(_modelItems[_selectedItemIndex]);
        }

        private void SelectModelItem(ModelItemUI modelItem)
        {
            _modelItems.ForEach(i => i.gameObject.SetActive(false));
            modelItem.gameObject.SetActive(true);
            _title.text = modelItem.ModelConfig.ModelName;
            _uiService.SelectModel(modelItem.ModelConfig);
        }
    }
}