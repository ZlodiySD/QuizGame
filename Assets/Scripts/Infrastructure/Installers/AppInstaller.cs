using DG.Tweening;
using QuizGame.Data;
using QuizGame.Infrastructure.Services;
using QuizGame.States;
using QuizGame.UI;
using UnityEngine;
using Zenject;

namespace QuizGame.Infrastructure.Installers
{
  //Game entry point
  public class AppInstaller : MonoInstaller, ICoroutineRunner, IInitializable
  {
    public GameRules GameRules;
    public LoadingFade LoadingFadePrefab;
    
    private Game _game;
  
    public override void InstallBindings()
    {
      BindLoadingFade();
      
      BindGameRules();

      BindInstallerInterfaces();
      BindSceneLoader();
      BindAssetProvider();
      BindGameTimer();

      BindUIFactory();

      StateMachineInstaller.Install(Container);
    }

    private void BindLoadingFade()
    {
      LoadingFade fade = Container.InstantiatePrefabForComponent<LoadingFade>(LoadingFadePrefab);
      
      Container
        .Bind<LoadingFade>()
        .FromInstance(fade);
    }

    private void BindGameRules() =>
      Container
        .Bind<GameRules>()
        .FromInstance(GameRules);

    private void BindInstallerInterfaces() =>
      Container
        .BindInterfacesTo<AppInstaller>()
        .FromInstance(this)
        .AsSingle()
        .NonLazy();

    private void BindSceneLoader() =>
      Container
        .Bind<SceneLoader>()
        .AsSingle()
        .NonLazy();

    private void BindAssetProvider() =>
      Container
        .Bind<IAssetProvider>()
        .To<AssetProvider>()
        .AsSingle()
        .NonLazy();

    private void BindGameTimer() =>
      Container
        .Bind<Timer>()
        .AsSingle()
        .NonLazy();

    private void BindUIFactory() =>
      Container
        .Bind<IUIFactory>()
        .To<UIFactory>()
        .AsSingle()
        .NonLazy();

    
    //Method called after all bindings
    public void Initialize()
    { 
      _game = Container.Instantiate<Game>();
      _game.StateMachine.Enter<MainMenuState>();

      DOTween.Init();
    }
  }
}