using Marbles.Code.Infrastructure.Factories;
using Marbles.Code.Logic.Marbles;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Marbles.Code.Logic
{
    public class RestartButton : MonoBehaviour
    {
        public Button Button;
        
        private IMarblesStorage _marblesStorage;
        private IMarblesSpawner _marblesSpawner;
        private IMarblesContainer _marblesContainer;

        [Inject]
        public void Construct(IMarblesStorage marblesStorage, IMarblesSpawner marblesSpawner, IMarblesContainer marblesContainer)
        {
            _marblesContainer = marblesContainer;
            _marblesSpawner = marblesSpawner;
            _marblesStorage = marblesStorage;
        }

        private void Awake()
        {
            Button.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            _marblesStorage.Clean();
            _marblesContainer.ClearMarblesContainer();
            _marblesSpawner.InstantiateMarbles();
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(Restart);
        }
    }
}