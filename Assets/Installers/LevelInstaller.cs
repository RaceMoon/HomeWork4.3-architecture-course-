using System;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private BallSpawner _ballSpawner;
    [SerializeField] private GameplaySceneHUD _gameplaySceneHUD;

    LevelLoadingData _loadingData;

    [Inject]
    private void Construct(LevelLoadingData loadingData)
    {
        _loadingData = loadingData;
    }
    public override void InstallBindings()
    {
        BindInput();
        BindSpawner();
        BindConditions();
    }
    private void BindInput()
    {
        Container.BindInterfacesAndSelfTo<BallClicker>().AsSingle();
    }

    private void BindSpawner()
    {
        Container.Bind<BallFactory>().AsSingle();
        Container.Bind<BallSpawner>().FromInstance(_ballSpawner).AsSingle();
    }

    private void BindConditions()
    {
        if (_loadingData.GameMode == GameModeType.BurstColorBall)
        {
            Container.Bind<VictoryCondition>().To<BurstColorBall>().AsSingle();
        }
        else if (_loadingData.GameMode == GameModeType.BurstAllBall)
        {
            Container.Bind<VictoryCondition>().To<BurstAllBall>().AsSingle();
        }

        Container.Bind<Level>().AsSingle().NonLazy();
        Container.Bind<Bootstrap>().AsSingle().NonLazy();
        Container.BindInstance(_gameplaySceneHUD).AsSingle();
        Container.BindInterfacesTo<GamePlayMediator>().AsSingle().NonLazy();
    }

}
