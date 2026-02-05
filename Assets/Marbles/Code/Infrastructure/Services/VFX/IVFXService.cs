using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.VFX
{
    public interface IVFXService
    {
        void SetVFXRoot(GameObject vfxRoot);

        void Play(ParticleSystem prefab, Vector3 worldPosition);

        void PlayMerge(Vector3 worldPosition);
        void PlayMergeFromScreenPosition(Vector2 screenPosition);
    }
}