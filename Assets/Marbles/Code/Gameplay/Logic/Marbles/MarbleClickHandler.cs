using Marbles.Code.Infrastructure.Factories;
using Marbles.Code.Infrastructure.Services.VFX;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Marbles.Code.Gameplay.Logic.Marbles
{
    public class MarbleClickHandler : MonoBehaviour, IPointerClickHandler
    {
        private IMarblesContainer _marblesContainer;
        private IMarblesStorage _marblesStorage;
        private IVFXService _ivfxService;

        [Inject]
        public void Construct(IMarblesContainer marblesContainer, IMarblesStorage marblesStorage, IVFXService ivfxService)
        {
            _marblesContainer = marblesContainer;
            _marblesStorage = marblesStorage;
            _ivfxService = ivfxService;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _ivfxService.PlayAddMarbleVFX(transform.position);
            Marble marble = GetComponent<Marble>();
            _marblesContainer.AddMarble(marble);
            _marblesStorage.RemoveMarble(marble);
        }
    }
}