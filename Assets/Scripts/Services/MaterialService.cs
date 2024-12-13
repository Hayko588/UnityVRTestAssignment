using UnityEngine;

namespace Services
{
    public class MaterialService : IMaterialService
    {
        private Renderer _currentRenderer;

        public void SetRenderer(Renderer renderer)
        {
            _currentRenderer = renderer;
        }

        public void ChangeColor(Color color)
        {
            if (_currentRenderer != null)
            {
                _currentRenderer.material.color = color;
            }
        }
    }
}