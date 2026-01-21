using System.Collections.Generic;
using Marbles.Code.Infrastructure.AssenManagement;
using Marbles.Code.Infrastructure.Services.PersistantProgress;
using Marbles.Code.Infrastructure.Services.StaticData;
using Marbles.Code.Logic;
using Marbles.Code.Logic.Marbles;
using UnityEngine;
using Zenject;

namespace Marbles.Code.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly DiContainer _container;
        private readonly IStaticDataService _staticDataService;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();

        public GameFactory(IAssetProvider assetProvider, DiContainer container, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _container = container;
            _staticDataService = staticDataService;
        }
        
        public GameObject CreateHud()
        {
            GameObject hudInstance = InstantiateRegistered(AssetPath.HudPath);
            BindMarblesContainer(hudInstance);
            SetupSlotViews(hudInstance);
            
            return hudInstance;
        }

        public GameObject CreateColliderBorders() => InstantiateRegistered(AssetPath.ColliderContainer);

        public GameObject CreateBackground() => InstantiateRegistered(AssetPath.BackgroundPath);

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private void BindMarblesContainer(GameObject hudInstance)
        {
            MarblesContainer handler = hudInstance.GetComponentInChildren<MarblesContainer>();
            _container.Bind<IMarblesContainer>().FromInstance(handler).AsSingle();
            _container.InjectGameObject(hudInstance);
        }

        private void SetupSlotViews(GameObject hudInstance)
        {
            MarblesContainer container = hudInstance.GetComponentInChildren<MarblesContainer>();
            Transform parent = container.transform;

            for (int i = 0; i < _staticDataService.GameConfig.SlotsCount; i++)
            {
                GameObject slotGo = InstantiateRegistered(AssetPath.SlotPath);
                slotGo.transform.SetParent(parent, false);
                
                SlotView slot = slotGo.GetComponent<SlotView>();
                container.RegisterSlot(slot);
            }
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assetProvider.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        
        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assetProvider.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponents<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}