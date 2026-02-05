using System;
using Marbles.Code.Gameplay.Windows.View;

namespace Marbles.Code.Gameplay.Logic.Marbles
{
    public interface IMarblesContainer
    {
        void AddMarble(Marble marble);
        void ClearMarblesContainer();
        bool IsFull { get; }
        void RegisterSlot(SlotView slotView);
        event Action OnMarbleAdded;
    }
}