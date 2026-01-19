using UnityEngine;

namespace Marbles.Code.Data.MarbleConfig
{
    [CreateAssetMenu(fileName = "MarbleConfig", menuName = "MarbleConfigs")]
    public class MarbleConfig : ScriptableObject
    {
        public GameObject Prefab;
        public MarbleType Type;
        public Sprite Sprite;
    }
}