using Marbles.Code.Gameplay.Cameras;
using Marbles.Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.VFX
{
    public class VFXService : IVFXService
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ICameraProvider _cameraProvider;
        private GameObject _vfxRoot;

        public VFXService(IStaticDataService staticDataService, ICameraProvider cameraProvider)
        {
            _staticDataService = staticDataService;
            _cameraProvider = cameraProvider;
        }

        public void SetVFXRoot(GameObject vfxRoot)
        {
            _vfxRoot = vfxRoot;
        }

        public void Play(ParticleSystem prefab, Vector3 position)
        {
            if (prefab == null || _vfxRoot == null)
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
        
        public void PlayMergeFromScreenPosition(Vector2 screenPosition)
        {
            if (_vfxRoot == null)
                return;

            Camera camera = _cameraProvider.MainCamera;
            if (camera == null)
            {
                PlayMerge(_vfxRoot.transform.position);
                return;
            }

            float distanceToVfxRoot = Mathf.Abs(_vfxRoot.transform.position.z - camera.transform.position.z);
            Vector3 worldPosition = camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceToVfxRoot));
            PlayMerge(worldPosition);
        }
    }
}