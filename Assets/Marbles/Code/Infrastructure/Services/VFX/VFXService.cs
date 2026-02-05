using Marbles.Code.Data.VFXs;
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

        public void PlayAddMarbleVFX(Vector3 position)
        {
            Play(_staticDataService.OnMarbleClickVFX, position);
        }

        public void PlayMergeFromScreenPosition(Vector2 screenPosition)
        {
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

        private void PlayMerge(Vector3 position)
        {
            Play(_staticDataService.MergeMarblesVFX, position);
        }

        private void Play(VFXConfig config, Vector3 position)
        {
            ParticleSystem particles = Object.Instantiate(
                config.ParticleSystem,
                position,
                Quaternion.identity,
                _vfxRoot.transform
            );

            particles.Play();

            ParticleSystem.MainModule main = particles.main;
            float lifetime = main.duration + main.startLifetime.constantMax;
            Object.Destroy(particles.gameObject, lifetime);
        }
    }
}