using System;
using Marbles.Code.Gameplay.Logic.Marbles;
using Marbles.Code.Infrastructure.Factories;
using Marbles.Code.Infrastructure.States;
using Zenject;

namespace Marbles.Code.Infrastructure.Services.RuleService
{
    public class GameRuleService : IGameRuleService, IInitializable, IDisposable
    {
        private readonly IMarblesContainer _marblesContainer;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IMarblesStorage _marblesStorage;

        public GameRuleService(
            IMarblesContainer marblesContainer,
            IGameStateMachine gameStateMachine,
            IMarblesStorage marblesStorage)
        {
            _marblesContainer = marblesContainer;
            _gameStateMachine = gameStateMachine;
            _marblesStorage = marblesStorage;
        }

        public void Initialize()
        {
            _marblesContainer.OnMarbleAdded += OnMarbleAdded;
        }

        public void Dispose()
        {
            _marblesContainer.OnMarbleAdded -= OnMarbleAdded;
        }

        private void OnMarbleAdded()
        {
            if (_marblesContainer.IsFull)
                _gameStateMachine.Enter<GameOverState>();
            
            if (_marblesStorage.Marbles.Count == 0)
                _gameStateMachine.Enter<GameWinState>();
        }
    }
}