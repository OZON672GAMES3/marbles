using Marbles.Code.Gameplay.Windows;

namespace Marbles.Code.Infrastructure.States
{
    public class GameOverState : IState
    {
        private readonly IWindowService _windowService;

        public GameOverState(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Enter()
        {
            _windowService.Open(WindowType.EndGameWindow);
        }

        public void Exit()
        {
            _windowService.Close(WindowType.EndGameWindow);
        }
    }
}