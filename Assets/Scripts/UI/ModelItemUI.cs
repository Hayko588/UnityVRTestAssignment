using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ModelItemUI : MonoBehaviour
    {
        [SerializeField] private RawImage _rawImage;

        public ModelConfig ModelConfig { get; private set; }

        public void Initialize(ModelConfig modelConfig)
        {
            ModelConfig = modelConfig;

            // var texture = AssetPreview.GetAssetPreview(modelConfig.Prefab.gameObject);
            // if (texture == null) return;
            // _image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}