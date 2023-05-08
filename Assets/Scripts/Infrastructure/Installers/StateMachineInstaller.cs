using QuizGame.States;
using Zenject;

namespace QuizGame.Infrastructure.Installers
{
  public class StateMachineInstaller : Installer<StateMachineInstaller>
  {
    private GameStateMachine _stateMachine;
  
    public override void InstallBindings()
    {
      _stateMachine = new GameStateMachine();
    
      Container
        .Bind<GameStateMachine>()
        .FromInstance(_stateMachine)
        .AsSingle();
    
      InitializeStates();
    }

    private void InitializeStates()
    {
      _stateMachine.AddState(typeof(MainMenuState), Container.Instantiate<MainMenuState>());
      _stateMachine.AddState(typeof(GameLoopState), Container.Instantiate<GameLoopState>());
    }
  }
}