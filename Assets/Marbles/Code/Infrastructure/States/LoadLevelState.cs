using Marbles.Code.Gameplay.Windows;
using Marbles.Code.Infrastructure.Factories;
using Marbles.Code.Infrastructure.SceneLoad;

namespace Marbles.Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IMarblesSpawner _marblesSpawner;
        private readonly IWindowService _windowService;

        public LoadLevelState(
            IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader,
            IGameFactory gameFactory, 
            IMarblesSpawner marblesSpawner,
            IWindowService windowService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _marblesSpawner = marblesSpawner;
            _windowService = windowService;
        }

        public void Enter(string payload)
        {
            _gameFactory.Cleanup();
            _sceneLoader.Load(payload, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            // _gameFactory.CreateHud();
            _windowService.Open(WindowType.MarblesUiWindow);
            _gameFactory.CreateBackground();
            _gameFactory.CreateColliderBorders();
            _marblesSpawner.InstantiateMarbles();

            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}