using System;
using System.Linq;
using UnityEngine;

public class ModelExhibit : MonoBehaviour
{
    [SerializeField] private Transform _rendererRoot;
    [SerializeField] private Animation _animationComponent;

    private Renderer _renderer;

    public Animation AnimationComponent => _animationComponent;

    private void Awake()
    {
        _renderer = _rendererRoot.GetComponents<Renderer>().First();
    }

    public Color GetBaseColor()
    {
        if (_renderer)
        {
            return _renderer.material.color;
        }
        else
        {
            return Color.white;
        }
    }

    public void SetBaseColor(Color color)
    {
        if (_renderer)
        {
            _renderer.material.color = color;
        }
    }
}