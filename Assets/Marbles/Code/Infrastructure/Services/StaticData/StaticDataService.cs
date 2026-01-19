using System.Collections.Generic;
using System.Linq;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Infrastructure.AssenManagement;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<MarbleType, MarbleConfig> _marbleConfigs = new();
        
        public MarbleConfig GetMarbleConfigByType(MarbleType type) => 
            _marbleConfigs.GetValueOrDefault(type);

        public void LoadAll()
        {
            LoadMarbleConfigs();
        }

        private void LoadMarbleConfigs()
        {
            MarbleConfig[] marbleConfigs = Resources.LoadAll<MarbleConfig>(AssetPath.MarblesPath);
            _marbleConfigs = marbleConfigs.ToDictionary(x => x.Type, x => x);
        }
    }
}