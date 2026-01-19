using System.Collections.Generic;
using Marbles.Code.Infrastructure.Services.PersistantProgress;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Factories
{
    public interface IGameFactory
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
        
        GameObject CreateHud();
        GameObject CreateBackground();
        GameObject CreateColliderBorders();
    }
}