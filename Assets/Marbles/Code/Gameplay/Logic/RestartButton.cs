using Marbles.Code.Gameplay.Logic.Marbles;
using Marbles.Code.Infrastructure.Factories;
using Marbles.Code.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Marbles.Code.Gameplay.Logic
{
    public class RestartButton : MonoBehaviour
    {
        public Button Button;
        
        private IMarblesStorage _marblesStorage;
        private IMarblesSpawner _marblesSpawner;
        private IMarblesContainer _marblesContainer;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(
            IMarblesStorage marblesStorage,
            IMarblesSpawner marblesSpawner,
            IMarblesContainer marblesContainer,
            IGameStateMachine gameStateMachine)
        {
            _marblesContainer = marblesContainer;
            _marblesSpawner = marblesSpawner;
            _marblesStorage = marblesStorage;
            _gameStateMachine = gameStateMachine;
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
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void OnDestroy()
        {
            Button.onClick.RemoveListener(Restart);
        }
    }
}