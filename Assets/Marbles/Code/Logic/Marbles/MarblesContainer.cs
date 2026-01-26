using System.Collections.Generic;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Infrastructure.Services.GameRuleService;
using Marbles.Code.Infrastructure.Services.MatchRule;
using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Logic.Marbles
{
    public class MarblesContainer : MonoBehaviour, IMarblesContainer
    {
        [HideInInspector]
        public List<SlotView> Slots = new();

        private readonly List<Marble> _marbles = new();
        private IStaticDataService _staticDataService;
        private IGameOverService _gameOverService;
        private IMatchRuleService _matchRuleService;

        public bool IsFull => _marbles.Count >= Slots.Count;

        [Inject]
        public void Construct(
            IStaticDataService staticDataService,
            IGameOverService gameOverService,
            IMatchRuleService matchRuleService)
        {
            _staticDataService = staticDataService;
            _gameOverService = gameOverService;
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

            CheckMatches();
            _gameOverService.OnMarbleAdded();
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
                    i = 0;
                    continue;
                }

                i = j;
            }
        }



        private void RemoveMatch(int endIndex, int matchCount)
        {
            int startIndex = endIndex - matchCount + 1;

            for (int i = endIndex; i >= startIndex; i--)
            {
                _marbles.RemoveAt(i);
                Slots[i].Clear();
            }

            Rearrange();
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
    }
}
