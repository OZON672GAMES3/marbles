using UnityEngine;

namespace Marbles.Code.Data.MarbleConfig
{
    [CreateAssetMenu(fileName = "MarbleConfig", menuName = "Configs/MarbleConfig")]
    public class MarbleConfig : ScriptableObject
    {
        public GameObject Prefab;
        public MarbleType Type;
        public Sprite Sprite;
    }
}