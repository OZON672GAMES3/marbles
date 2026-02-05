using UnityEngine;

namespace Marbles.Code.Gameplay.Cameras
{
    public class CameraProvider : ICameraProvider
    {
        private Camera _mainCamera;

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = Camera.main;
                
                return _mainCamera;
            }
            
            private set => _mainCamera = value;
        }

        public void SetMainCamera(Camera camera) => 
            MainCamera = camera;
    }
}