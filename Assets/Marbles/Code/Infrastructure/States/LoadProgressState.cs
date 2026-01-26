using Marbles.Code.Common.Constants;
using Marbles.Code.Data;
using Marbles.Code.Infrastructure.Services.PersistantProgress;
using Marbles.Code.Infrastructure.Services.SaveLoad;

namespace Marbles.Code.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(IGameStateMachine gameStateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _gameStateMachine.Enter<LoadLevelState,string>(_progressService.Progress.SceneName);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew() => 
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

        private PlayerProgress NewProgress() => new(Scenes.Main);
    }
}