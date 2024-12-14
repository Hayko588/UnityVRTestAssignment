using UnityEngine;

public class ModelExhibit : MonoBehaviour
{
    private static readonly int ColorProperty = Shader.PropertyToID("_BaseColor");
    [SerializeField] private Material _targetMaterial;
    [SerializeField] private Animation _animationComponent;

    public Material TargetMaterial => _targetMaterial;
    public Animation AnimationComponent => _animationComponent;

    public Color GetBaseColor()
    {
        if (_targetMaterial.HasProperty(ColorProperty))
        {
            return _targetMaterial.GetColor(ColorProperty);
        }
        else
        {
            return Color.white;
        }
    }

    public void SetBaseColor(Color color)
    {
        if (_targetMaterial.HasProperty(ColorProperty))
        {
            _targetMaterial.SetColor(ColorProperty, color);
        }
    }
}