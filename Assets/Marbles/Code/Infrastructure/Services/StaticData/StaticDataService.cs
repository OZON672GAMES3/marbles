using System.Collections.Generic;
using System.Linq;
using Marbles.Code.Data;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Data.VFXs;
using Marbles.Code.Gameplay.Windows;
using Marbles.Code.Gameplay.Windows.Config;
using Marbles.Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<MarbleType, MarbleConfig> _marbleConfigs = new();
        private Dictionary<WindowType, WindowConfig> _windowConfigs = new();
        
        private GameConfig _gameConfig;
        private VFXConfig _onMarbleClickVFX;
        private VFXConfig _mergeMarblesVFX;

        public VFXConfig OnMarbleClickVFX => _onMarbleClickVFX; 
        
        public VFXConfig MergeMarblesVFX => _mergeMarblesVFX;
        
        public GameConfig GameConfig => _gameConfig;
        
        public MarbleConfig GetMarbleConfigByType(MarbleType type) => 
            _marbleConfigs.GetValueOrDefault(type);

        public WindowConfig GetWindowConfigByType(WindowType type) =>
            _windowConfigs.GetValueOrDefault(type);

        public void LoadAll()
        {
            LoadMarbleConfigs();
            LoadGameConfig();
            LoadWindowConfig();
            LoadVFXConfigs();
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

        private void LoadWindowConfig()
        {
            WindowConfig[] windowConfigs = Resources.LoadAll<WindowConfig>(AssetPath.WindowConfigPath);
            _windowConfigs = windowConfigs.ToDictionary(x => x.Type, x => x);
        }

        private void LoadVFXConfigs()
        {
            _onMarbleClickVFX = Resources.Load<VFXConfig>(AssetPath.OnMarbleClickVFXPath);
            _mergeMarblesVFX = Resources.Load<VFXConfig>(AssetPath.OnMarblesMergeVFXPath);
        }
    }
}