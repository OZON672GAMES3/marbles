using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Infrastructure.Services.StaticData;
using Marbles.Code.Logic.Marbles;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Infrastructure.Factories
{
    public class MarblesFactory : IMarblesFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;

        public MarblesFactory(IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
        }

        public Marble InstantiateMarble(MarbleType type, Vector3 localPos)
        {
            MarbleConfig marbleConfig = _staticDataService.GetMarbleConfigByType(type);
            Marble marble = _instantiator.InstantiatePrefabForComponent<Marble>(marbleConfig.Prefab, localPos, Quaternion.identity, null);
            marble.Config = marbleConfig;
            return marble;
        }
    }
}