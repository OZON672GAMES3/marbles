using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Gameplay.Windows
{
    public class WindowFactory : IWindowFactory
    {
        private readonly IStaticDataService _staticData;
        private readonly IInstantiator _instantiator;
        private RectTransform _uiRoot;

        public WindowFactory(IStaticDataService staticData, IInstantiator instantiator)
        {
            _staticData = staticData;
            _instantiator = instantiator;
        }

        public void SetUIRoot(RectTransform uiRoot) =>
            _uiRoot = uiRoot;

        public Window CreateWindow(WindowType windowType) =>
            _instantiator.InstantiatePrefabForComponent<Window>(PrefabFor(windowType), _uiRoot);

        private GameObject PrefabFor(WindowType windowType) =>
            _staticData.GetWindowConfigByType(windowType).Prefab;
    }
}