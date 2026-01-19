using System;

namespace Marbles.Code.Infrastructure.SceneLoad
{
    public interface ISceneLoader
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}