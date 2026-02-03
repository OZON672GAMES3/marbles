namespace Marbles.Code.Gameplay.Windows
{
    public interface IWindowService
    {
        void Open(WindowType windowType);
        void Close(WindowType windowType);
    }
}