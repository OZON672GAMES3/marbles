using UnityEngine;

namespace Marbles.Code.Infrastructure.Services.VFX
{
    public interface IVFXService
    {
        void SetVFXRoot(GameObject vfxRoot);
        void PlayAddMarbleVFX(Vector3 position);
        void PlayMergeFromScreenPosition(Vector2 screenPosition);
    }
}