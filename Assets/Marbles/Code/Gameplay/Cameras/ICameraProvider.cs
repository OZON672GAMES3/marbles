using UnityEngine;

namespace Marbles.Code.Gameplay.Cameras
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        void SetMainCamera(Camera camera);
    }
}