using QuizGame.Controllers;
using QuizGame.Data;
using QuizGame.Infrastructure;
using QuizGame.Infrastructure.Services;
using QuizGame.Logic;
using QuizGame.UI;
using QuizGame.UI.Views;

namespace QuizGame.States
{
  //State responding transition to the game loop and setting the game loop
  public class GameLoopState : IState
  {
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly IUIFactory _uiFactory;
    private readonly GameRules _gameRules;
    private readonly Timer _timer;
    private readonly LoadingFade _loadingFade;

    private readonly string _gameScene = "Game";
    private GameLoopRunner _gameRunner;
    private QuizViewController _quizViewController;

    public GameLoopState(SceneLoader sceneLoader, GameStateMachine stateMachine, IUIFactory uiFactory, GameRules gameRules, Timer timer, LoadingFade loadingFade)
    {
      _sceneLoader = sceneLoader;
      _stateMachine = stateMachine;
      _uiFactory = uiFactory;
      _gameRules = gameRules;
      _timer = timer;
      _loadingFade = loadingFade;
    }
  
    public void Exit()
    {
      _uiFactory.DestroyUIRoot();
    }

    public void Enter()
    {
      _loadingFade.Show();
      _sceneLoader.Load(_gameScene, SetupScene);
    }
  
    private void SetupScene()
    { 
      _uiFactory.CreateUIRoot();
    
      SetupGameRunner();
      SetupQuiz();
      EventSubscription();  
      
      _gameRunner.StartNewGame();
    }

    private void SetupQuiz()
    {
      QuizView quizView = _uiFactory.CreateQuizView().GetComponent<QuizView>();
      quizView.answerHolderView.Construct(_uiFactory);
    
      _quizViewController = new QuizViewController(quizView);
    }

    private void SetupGameRunner()
    {
      _gameRunner = new GameLoopRunner(_gameRules, _timer);
    }

    private void EventSubscription()
    {
      _gameRunner.QuestionAsked += _quizViewController.SetupQuizView;
      _timer.TimerChanged += _quizViewController.UpdateTimer;
      _quizViewController.AnswerClicked += _gameRunner.AnswerProceed;

      _gameRunner.WrongAnswered += _quizViewController.OnWrongAnswer;
    
      _gameRunner.GameLossed += () => SetupGameEnd("Game Over");
      _gameRunner.GameWined += () => SetupGameEnd("Win");

    }

    private void SetupGameEnd(string message)
    {
      GameEndView gameEndView = _uiFactory.CreateGameEndView().GetComponent<GameEndView>();
      gameEndView.SetText(message);
      gameEndView.MainMenuClicked += () => _stateMachine.Enter<MainMenuState>();
    }
  }
}