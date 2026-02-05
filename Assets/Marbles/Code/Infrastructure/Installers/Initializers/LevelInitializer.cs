using Marbles.Code.Gameplay.Cameras;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Infrastructure.Installers.Initializers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Camera MainCamera;
        
        private ICameraProvider _cameraProvider;

        [Inject]
        public void Construct(ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }
        
        public void Initialize()
        {
            _cameraProvider.SetMainCamera(MainCamera);
        }
    }
}