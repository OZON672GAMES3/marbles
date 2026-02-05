using Marbles.Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Infrastructure.Installers.Initializers
{
    public class UIInitializer: MonoBehaviour, IInitializable
    {
        public RectTransform UIRoot;
        
        private IWindowFactory _windowFactory;

        [Inject]
        public void Construct(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public void Initialize()
        {
            _windowFactory.SetUIRoot(UIRoot);
        }
    }
}