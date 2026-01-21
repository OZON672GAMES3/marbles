using Marbles.Code.Infrastructure.AssenManagement;
using Marbles.Code.Infrastructure.Factories;
using Marbles.Code.Infrastructure.SceneLoad;
using Marbles.Code.Infrastructure.Services.GameRuleService;
using Marbles.Code.Infrastructure.Services.PersistantProgress;
using Marbles.Code.Infrastructure.Services.SaveLoad;
using Marbles.Code.Infrastructure.Services.StaticData;
using Marbles.Code.Infrastructure.States;
using Marbles.Code.Infrastructure.States.Factory;
using Zenject;

namespace Marbles.Code.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IGameOverService>().To<GameOverService>().AsSingle();

            BindSelf();

            BindStateMachine();
            BindFactories();
            BindSaveLoadServices();
            BindLogic();
        }

        private void BindLogic()
        {
            Container.Bind<IMarblesSpawner>().To<MarblesSpawner>().AsSingle();
            Container.Bind<IMarblesStorage>().To<MarblesStorage>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IMarblesFactory>().To<MarblesFactory>().AsSingle();
        }

        private void BindSaveLoadServices()
        {
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        }

        private void BindSelf()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLoopState>().AsSingle();
        }
    }
}