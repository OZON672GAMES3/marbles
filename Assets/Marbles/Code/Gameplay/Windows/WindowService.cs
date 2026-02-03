using System.Collections.Generic;
using UnityEngine;

namespace Marbles.Code.Gameplay.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IWindowFactory _windowFactory;

        private readonly List<Window> _openedWindows = new();

        public WindowService(IWindowFactory windowFactory) => 
            _windowFactory = windowFactory;

        public void Open(WindowType windowType)
        {
            Window window = _windowFactory.CreateWindow(windowType);
            window.Type = windowType;
            _openedWindows.Add(window);
        }

        public void Close(WindowType windowType)
        {
            Window window = _openedWindows.Find(w => w.Type == windowType);

            _openedWindows.Remove(window);
            
            GameObject.Destroy(window.gameObject);
        }
    }
}