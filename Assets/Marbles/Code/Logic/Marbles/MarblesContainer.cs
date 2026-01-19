using System.Collections.Generic;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Logic.Marbles
{
    public class MarblesContainer : MonoBehaviour, IMarblesContainer
    {
        [HideInInspector]
        public List<SlotView> Slots;

        private readonly List<Marble> _marbles = new();
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void AddMarble(Marble marble)
        {
            if (_marbles.Count >= Slots.Count)
                return;

            _marbles.Add(marble);

            int index = _marbles.Count - 1;

            MarbleConfig config =
                _staticDataService.GetMarbleConfigByType(marble.Config.Type);
            
            Slots[index].SetSprite(config.Sprite);

            CheckMatches();
        }

        public void ClearMarblesContainer()
        {
            _marbles.Clear();
        }

        private void CheckMatches()
        {
            if (_marbles.Count < 3)
                return;

            int count = 1;

            for (int i = 1; i < _marbles.Count; i++)
            {
                if (_marbles[i].Config.Type == _marbles[i - 1].Config.Type)
                {
                    count++;

                    if (count >= 3)
                    {
                        RemoveMatch(i);
                        return;
                    }
                }
                else
                {
                    count = 1;
                }
            }
        }

        private void RemoveMatch(int endIndex)
        {
            int startIndex = endIndex - 2;

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
                MarbleConfig config =
                    _staticDataService.GetMarbleConfigByType(_marbles[i].Config.Type);

                Slots[i].SetSprite(config.Sprite);
            }
            
            for (int i = _marbles.Count; i < Slots.Count; i++)
                Slots[i].Clear();
        }
    }
}
