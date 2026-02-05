using Marbles.Code.Data;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Gameplay.Logic;
using Marbles.Code.Gameplay.Windows;
using Marbles.Code.Gameplay.Windows.Config;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        MarbleConfig GetMarbleConfigByType(MarbleType type);
        void LoadAll();
        GameConfig GameConfig { get; }
        ParticleSystem ParticleSystem { get; }
        ParticleSystem MergeParticleSystem { get; }
        WindowConfig GetWindowConfigByType(WindowType type);
    }
}