using System;

namespace Marbles.Code.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public string SceneName;
        public int MaxScore;

        public PlayerProgress(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}