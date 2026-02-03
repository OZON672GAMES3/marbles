using Marbles.Code.Gameplay.Windows;

namespace Marbles.Code.Infrastructure.States
{
    public class GameWinState : IState
    {
        private readonly IWindowService _windowService;

        public GameWinState(IWindowService windowService)
        {
            _windowService = windowService;
        }

        public void Enter()
        {
            _windowService.Open(WindowType.WinGameWindow);
        }

        public void Exit()
        {
            _windowService.Close(WindowType.WinGameWindow);
        }
    }
}