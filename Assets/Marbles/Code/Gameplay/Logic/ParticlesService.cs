using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Marbles.Code.Gameplay.Logic
{
    public class ParticlesService : IParticlesService
    {
        private readonly IStaticDataService _staticData;
        private readonly GameObject _vfxRoot;

        public ParticlesService(IStaticDataService staticData)
        {
            _staticData = staticData;
            GameObject vfxRoot = new GameObject("VFXRoot");
            _vfxRoot = vfxRoot;
        }

        public void Play(Vector3 position)
        {
            ParticleSystem particleSystem = _staticData.ParticleSystem;

            ParticleSystem particles = Object.Instantiate(particleSystem, position, Quaternion.identity, _vfxRoot.transform);
            particles.Play();
            
            Object.Destroy(particles.gameObject, particles.main.duration);
        }
    }
}