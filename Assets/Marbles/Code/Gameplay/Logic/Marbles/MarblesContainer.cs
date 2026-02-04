using System;
using System.Collections.Generic;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Gameplay.Windows.View;
using Marbles.Code.Infrastructure.Services.RuleService.MatchRule;
using Marbles.Code.Infrastructure.Services.StaticData;

namespace Marbles.Code.Gameplay.Logic.Marbles
{
    public class MarblesContainer : IMarblesContainer
    {
        public List<SlotView> Slots = new();
        public event Action OnMarbleAdded;

        private readonly List<Marble> _marbles = new();
        private readonly IStaticDataService _staticDataService;
        private readonly IMatchRuleService _matchRuleService;
        
        private bool _isResolvingMatch;
        private bool _pendingMarbleAddedNotification;
        
        public bool IsFull => _marbles.Count >= Slots.Count;

        public MarblesContainer(
            IStaticDataService staticDataService,
            IMatchRuleService matchRuleService)
        {
            _staticDataService = staticDataService;
            _matchRuleService = matchRuleService;
        }

        public void AddMarble(Marble marble)
        {
            if (_marbles.Count >= Slots.Count)
                return;
            
            _marbles.Add(marble);
            
            int index = _marbles.Count - 1;
            MarbleConfig config = _staticDataService.GetMarbleConfigByType(marble.Config.Type);
            Slots[index].SetSprite(config.Sprite);
            
            _pendingMarbleAddedNotification = true;
            CheckMatches();
        }
        
        public void FinalizeMarbleAdded()
        {
            NotifyMarbleAddedIfReady();
        }

        public void RegisterSlot(SlotView slotView)
        {
            Slots.Add(slotView);
        }

        public void ClearMarblesContainer()
        {
            _marbles.Clear();
            foreach (SlotView slot in Slots)
                slot.Clear();
        }

        private void CheckMatches()
        {
            if (_isResolvingMatch)
                return;

            if (_marbles.Count < 2)
                return;

            int i = 0;

            while (i < _marbles.Count)
            {
                MarbleType type = _marbles[i].Config.Type;

                if (!_matchRuleService.TryGetMatchLength(type, out int requiredLength))
                {
                    i++;
                    continue;
                }

                int count = 1;
                int j = i + 1;

                while (j < _marbles.Count && _marbles[j].Config.Type == type)
                {
                    count++;
                    j++;
                }

                if (count >= requiredLength)
                {
                    RemoveMatch(j - 1, count);
                    return;
                }

                i = j;
            }
        }

        private void RemoveMatch(int endIndex, int matchCount)
        {
            _isResolvingMatch = true;
            int startIndex = endIndex - matchCount + 1;
            SlotView targetSlot = Slots[startIndex];
            int remainingAnimations = matchCount - 1;
            const float moveDuration = 0.25f;
            const float fadeDuration = 0.2f;

            if (remainingAnimations > 0)
            {
                for (int i = endIndex; i > startIndex; i--)
                {
                    int currentIndex = i;
                    SlotView slot = Slots[currentIndex];
                    slot.AnimateMergeTo(targetSlot, moveDuration, fadeDuration, 0f, () =>
                    {
                        RemoveAt(currentIndex);
                        remainingAnimations--;
                        if (remainingAnimations == 0)
                            RemoveMatchAnchor(startIndex, targetSlot, moveDuration, fadeDuration);
                    });
                }
            }
            else
            {
                RemoveMatchAnchor(startIndex, targetSlot, moveDuration, fadeDuration);
            }
        }

        private void RemoveMatchAnchor(int startIndex, SlotView targetSlot, float moveDuration, float fadeDuration)
        {
            targetSlot.AnimateMergeTo(targetSlot, moveDuration, fadeDuration, moveDuration, () =>
            {
                RemoveAt(startIndex);
                Rearrange();
                _isResolvingMatch = false;
                CheckMatches();
                NotifyMarbleAddedIfReady();
            });
        }

        private void RemoveAt(int index)
        {
            _marbles.RemoveAt(index);
            Slots[index].Clear();
        }

        private void Rearrange()
        {
            for (int i = 0; i < _marbles.Count; i++)
            {
                MarbleConfig config = _staticDataService.GetMarbleConfigByType(_marbles[i].Config.Type);
                Slots[i].SetSprite(config.Sprite);
            }

            for (int i = _marbles.Count; i < Slots.Count; i++)
                Slots[i].Clear();
        }
        
        private void NotifyMarbleAddedIfReady()
        {
            if (_isResolvingMatch || !_pendingMarbleAddedNotification)
                return;

            _pendingMarbleAddedNotification = false;
            OnMarbleAdded?.Invoke();
        }
    }
}
