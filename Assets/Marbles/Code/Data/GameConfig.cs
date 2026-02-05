using UnityEngine;

namespace Marbles.Code.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [Header("Slots for marbles")]
        public int SlotsCount;
        
        [Header("Marbles count")]
        public int RedMarblesCount;
        public int BlueMarblesCount;
        public int YellowMarblesCount;
        public int GreenMarblesCount;
        
        private void OnValidate()
        {
            SlotsCount = Mathf.Max(0, SlotsCount);

            RedMarblesCount    = Mathf.Clamp(RedMarblesCount, 0, SlotsCount);
            BlueMarblesCount   = Mathf.Clamp(BlueMarblesCount, 0, SlotsCount);
            YellowMarblesCount = Mathf.Clamp(YellowMarblesCount, 0, SlotsCount);
            GreenMarblesCount  = Mathf.Clamp(GreenMarblesCount, 0, SlotsCount);
        }
    }
}