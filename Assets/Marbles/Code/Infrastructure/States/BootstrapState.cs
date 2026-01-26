using Marbles.Code.Common.Constants;
using Marbles.Code.Infrastructure.SceneLoad;
using Marbles.Code.Infrastructure.Services.StaticData;

namespace Marbles.Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader,
            IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _staticDataService.LoadAll();

            _sceneLoader.Load(Scenes.Boot, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }
    }
}