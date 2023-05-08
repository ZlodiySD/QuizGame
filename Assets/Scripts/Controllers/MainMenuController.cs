using QuizGame.Infrastructure;
using QuizGame.States;
using QuizGame.UI.Views;

namespace QuizGame.Controllers
{
  public class MainMenuController
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly MainMenuView _mainMenuView;

    public MainMenuController(GameStateMachine gameStateMachine, MainMenuView mainMenuView)
    {
      _gameStateMachine = gameStateMachine;
      _mainMenuView = mainMenuView;
    }

    public void SubscribeToActions()
    {
      _mainMenuView.PlayClicked+= MainMenuViewOnPlayClicked;   
    }

    private void MainMenuViewOnPlayClicked()
    {
      _gameStateMachine.Enter<GameLoopState>();
    }

    public void SetBestTime(int bestTime)
    {
      _mainMenuView.SetBestTime(Extensions.TimeInSecondsToString(bestTime));
    }
  }
}