namespace Marbles.Code.Gameplay.Windows.View
{
    public class WinGameView : Window
    {
        protected override void Initialize()
        {
            gameObject.SetActive(true);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            gameObject.SetActive(false);
        }
    }
}