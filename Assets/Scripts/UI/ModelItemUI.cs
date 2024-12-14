using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ModelItemUI : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public ModelConfig ModelConfig { get; private set; }

        public void Initialize(ModelConfig modelConfig)
        {
            ModelConfig = modelConfig;
            _image.sprite = modelConfig.PreviewImage;
        }
    }
}