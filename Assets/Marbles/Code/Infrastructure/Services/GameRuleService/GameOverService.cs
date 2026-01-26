using Marbles.Code.Infrastructure.States;
using Marbles.Code.Logic.Marbles;

namespace Marbles.Code.Infrastructure.Services.GameRuleService
{
    public class GameOverService : IGameOverService
    {
        private readonly IMarblesContainer _container;
        private readonly IGameStateMachine _gameStateMachine;

        public GameOverService(IMarblesContainer container, IGameStateMachine gameStateMachine)
        {
            _container = container;
            _gameStateMachine = gameStateMachine;
        }

        public void OnMarbleAdded()
        {
            if (_container.IsFull)
            {
                Resolve();
            }
        }

        private void Resolve()
        {
            _gameStateMachine.Enter<GameOverState>();
        }
    }
}