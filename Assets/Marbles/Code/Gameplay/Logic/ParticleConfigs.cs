using UnityEngine;

namespace Marbles.Code.Gameplay.Logic
{
    [CreateAssetMenu(fileName = "ParticleConfig", menuName = "Configs/ParticleConfig")]
    public class ParticleConfigs : ScriptableObject
    {
        public ParticleSystem ParticleSystem;
    }
}