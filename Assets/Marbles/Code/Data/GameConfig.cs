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
    }
}