using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.VFX
{
    public class VFXService : IVFXService
    {
        private readonly IStaticDataService _staticDataService;
        private GameObject _vfxRoot;

        public VFXService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void SetVFXRoot(GameObject vfxRoot)
        {
            _vfxRoot = vfxRoot;
        }

        public void Play(ParticleSystem prefab, Vector3 position)
        {
            if (prefab == null)
                return;
            
            ParticleSystem particles = Object.Instantiate(prefab, position, Quaternion.identity, _vfxRoot.transform);
            particles.Play();
            
            ParticleSystem.MainModule mainModule = particles.main;
            float lifetime = mainModule.duration + mainModule.startLifetime.constantMax;
            Object.Destroy(particles.gameObject, lifetime);
        }

        public void PlayMerge(Vector3 position)
        {
            Play(_staticDataService.MergeParticleSystem, position);
        }
    }
}