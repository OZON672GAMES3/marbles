using Marbles.Code.Infrastructure.Factories;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Marbles.Code.Gameplay.Logic.Marbles
{
    public class MarbleClickHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ParticleSystem _clickVfx;
        
        private IMarblesContainer _marblesContainer;
        private IMarblesStorage _marblesStorage;
        private IParticlesService _particlesService;

        [Inject]
        public void Construct(IMarblesContainer marblesContainer, IMarblesStorage marblesStorage, IParticlesService particlesService)
        {
            _marblesContainer = marblesContainer;
            _marblesStorage = marblesStorage;
            _particlesService = particlesService;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            _particlesService.Play(transform.position);
            Marble marble = GetComponent<Marble>();
            _marblesContainer.AddMarble(marble);
            _marblesStorage.RemoveMarble(marble);
        }
    }
}