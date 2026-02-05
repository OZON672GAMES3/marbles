using UnityEngine;

namespace Marbles.Code.Data.VFXs
{
    [CreateAssetMenu(fileName = "VFXConfig", menuName = "Configs/VFXConfig")]
    public class VFXConfig : ScriptableObject
    {
        public ParticleSystem ParticleSystem;
    }
}