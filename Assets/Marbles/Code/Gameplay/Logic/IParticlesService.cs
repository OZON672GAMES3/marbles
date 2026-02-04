using UnityEngine;

namespace Marbles.Code.Gameplay.Logic
{
    public interface IParticlesService
    {
        void Play(ParticleSystem prefab, Vector3 position);
    }
}