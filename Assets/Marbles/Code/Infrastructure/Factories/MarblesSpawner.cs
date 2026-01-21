using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Infrastructure.Services.StaticData;
using Marbles.Code.Logic.Marbles;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Factories
{
    public class MarblesSpawner : IMarblesSpawner
    {
        private readonly IMarblesFactory _marblesFactory;
        private readonly IMarblesStorage _marblesStorage;
        private readonly IStaticDataService _staticDataService;

        public MarblesSpawner(IMarblesFactory marblesFactory, IMarblesStorage marblesStorage, IStaticDataService staticDataService)
        {
            _marblesFactory = marblesFactory;
            _marblesStorage = marblesStorage;
            _staticDataService = staticDataService;
        }

        public void InstantiateMarbles()
        {
            Spawn(MarbleType.Red, _staticDataService.GameConfig.RedMarblesCount);
            Spawn(MarbleType.Yellow, _staticDataService.GameConfig.YellowMarblesCount);
            Spawn(MarbleType.Blue, _staticDataService.GameConfig.BlueMarblesCount);
            Spawn(MarbleType.Green, _staticDataService.GameConfig.GreenMarblesCount);
        }

        private void Spawn(MarbleType type, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Marble marble = _marblesFactory.InstantiateMarble(type, new Vector3(
                    Random.Range(-2f, 2f),
                    Random.Range(2f, 4f),
                    0f));
                
                _marblesStorage.Marbles.Add(marble);
            }
        }
    }
}