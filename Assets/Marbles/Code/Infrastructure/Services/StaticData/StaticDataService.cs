using System.Collections.Generic;
using System.Linq;
using Marbles.Code.Data;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<MarbleType, MarbleConfig> _marbleConfigs = new();
        private GameConfig _gameConfig;

        public GameConfig GameConfig => _gameConfig;
        public MarbleConfig GetMarbleConfigByType(MarbleType type) => 
            _marbleConfigs.GetValueOrDefault(type);

        public void LoadAll()
        {
            LoadMarbleConfigs();
            LoadGameConfig();
        }

        private void LoadMarbleConfigs()
        {
            MarbleConfig[] marbleConfigs = Resources.LoadAll<MarbleConfig>(AssetPath.MarblesPath);
            _marbleConfigs = marbleConfigs.ToDictionary(x => x.Type, x => x);
        }

        private void LoadGameConfig()
        {
            _gameConfig = Resources.Load<GameConfig>(AssetPath.GameConfigPath);
        }
    }
}