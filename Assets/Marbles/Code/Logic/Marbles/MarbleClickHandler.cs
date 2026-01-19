using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Marbles.Code.Logic.Marbles
{
    public class MarbleClickHandler : MonoBehaviour, IPointerClickHandler
    {
        private IMarblesContainer _marblesContainer;

        [Inject]
        public void Construct(IMarblesContainer marblesContainer)
        {
            _marblesContainer = marblesContainer;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Marble marble = GetComponent<Marble>();
            _marblesContainer.AddMarble(marble);
            Destroy(marble.gameObject);
        }
    }
}