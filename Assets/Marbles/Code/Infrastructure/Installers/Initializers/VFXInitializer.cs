using Marbles.Code.Gameplay.Cameras;
using Marbles.Code.Infrastructure.Services.VFX;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Infrastructure.Installers.Initializers
{
    public class VFXInitializer : MonoBehaviour, IInitializable
    {
        public GameObject VFXRoot;
        private IVFXService _vfxService;
        private ICameraProvider _cameraProvider;

        [Inject]
        public void Construct(ICameraProvider cameraProvider, IVFXService vfxService)
        {
            _cameraProvider = cameraProvider;
            _vfxService = vfxService;
        }

        public void Initialize()
        {
            _vfxService.SetVFXRoot(VFXRoot);
        }
    }
}