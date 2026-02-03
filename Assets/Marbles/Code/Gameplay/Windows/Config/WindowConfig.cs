using UnityEngine;

namespace Marbles.Code.Gameplay.Windows.Config
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "Configs/WindowConfig")]
    public class WindowConfig : ScriptableObject
    {
        public WindowType Type;
        public GameObject Prefab;
    }
}