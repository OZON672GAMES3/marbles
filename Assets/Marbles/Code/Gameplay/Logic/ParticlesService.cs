using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Marbles.Code.Gameplay.Logic
{
    public class ParticlesService : IParticlesService
    {
        private readonly GameObject _vfxRoot;

        public ParticlesService()
        {
            GameObject vfxRoot = new GameObject("VFXRoot");
            _vfxRoot = vfxRoot;
        }

        public void Play(ParticleSystem prefab, Vector3 position)
        {
            if (prefab == null)
            {
                return;
            }

            ParticleSystem particles = Object.Instantiate(prefab, position, Quaternion.identity, _vfxRoot.transform);
            particles.Play();

            ParticleSystem.MainModule mainModule = particles.main;
            float lifetime = mainModule.duration + mainModule.startLifetime.constantMax;
            Object.Destroy(particles.gameObject, lifetime);
        }
    }
}