namespace Marbles.Code.Logic.Marbles
{
    public interface IMarblesContainer
    {
        void AddMarble(Marble marble);
        void ClearMarblesContainer();
        bool IsFull { get; }
        void RegisterSlot(SlotView slotView);
    }
}