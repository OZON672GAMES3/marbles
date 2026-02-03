using Marbles.Code.Gameplay.Logic;
using Marbles.Code.Gameplay.Logic.Marbles;
using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Gameplay.Windows.View
{
    public class MarbleContainerView : Window
    {
        [SerializeField] private SlotView _slotPrefab;

        private IMarblesContainer _marblesContainer;
        private IInstantiator _instantiator;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(
            IMarblesContainer marblesContainer,
            IInstantiator instantiator,
            IStaticDataService staticDataService)
        {
            _marblesContainer = marblesContainer;
            _instantiator = instantiator;
            _staticDataService = staticDataService;
        }

        protected override void Initialize()
        {
            SpawnSlots();
        }

        private void SpawnSlots()
        {
            for (int i = 0; i < _staticDataService.GameConfig.SlotsCount; i++)
            {
                SlotView slot = _instantiator.InstantiatePrefabForComponent<SlotView>(_slotPrefab, transform);

                _marblesContainer.RegisterSlot(slot);
            }
        }
    }
}