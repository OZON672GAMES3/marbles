using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Logic.Marbles;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Factories
{
    public class MarblesSpawner : IMarblesSpawner
    {
        private readonly IMarblesFactory _marblesFactory;
        private readonly IMarblesStorage _marblesStorage;

        public MarblesSpawner(IMarblesFactory marblesFactory, IMarblesStorage marblesStorage)
        {
            _marblesFactory = marblesFactory;
            _marblesStorage = marblesStorage;
        }

        public void InstantiateMarbles()
        {
            Spawn(MarbleType.Red);
            Spawn(MarbleType.Yellow);
            Spawn(MarbleType.Blue);
            Spawn(MarbleType.Green);
        }

        private void Spawn(MarbleType type)
        {
            for (int i = 0; i < 3; i++)
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