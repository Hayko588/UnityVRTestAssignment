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

            var texture = AssetPreview.GetAssetPreview(modelConfig.Prefab.gameObject);
            _image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}