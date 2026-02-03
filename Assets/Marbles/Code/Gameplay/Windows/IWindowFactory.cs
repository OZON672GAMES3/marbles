using UnityEngine;

namespace Marbles.Code.Gameplay.Windows
{
    public interface IWindowFactory
    {
        void SetUIRoot(RectTransform uiRoot);
        Window CreateWindow(WindowType windowType);
    }
}