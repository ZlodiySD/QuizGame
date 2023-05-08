using QuizGame.Controllers;
using QuizGame.Data;
using QuizGame.Infrastructure;
using QuizGame.Infrastructure.Services;
using QuizGame.UI;
using QuizGame.UI.Views;
using UnityEngine;

namespace QuizGame.States
{
  //State responding transition to the main menu and setting the main menu
  public class MainMenuState : IState
  {
    private readonly SceneLoader _sceneLoader;
    private readonly GameStateMachine _stateMachine;
    private readonly IUIFactory _uiFactory;
    private readonly LoadingFade _loadingFade;
    private readonly string MainMenu = "MainMenu";
  
    private MainMenuView _mainMenuView;
    private MainMenuController _mainMenuController;
  
    public MainMenuState(SceneLoader sceneLoader, GameStateMachine gameStateMachine, IUIFactory uiFactory, LoadingFade loadingFade)
    {
      _sceneLoader = sceneLoader;
      _stateMachine = gameStateMachine;
      _uiFactory = uiFactory;
      _loadingFade = loadingFade;
    }
  
    public void Exit()
    {
      
    }

    public void Enter()
    {
      _loadingFade.Show();
      _sceneLoader.Load(MainMenu, InitializeScene);
    }

    private void InitializeScene()
    {
      CreateUIRoot();
      SetupMainMenu();
    }

    private void CreateUIRoot() => 
      _uiFactory.CreateUIRoot();

    private void SetupMainMenu()
    {
      _mainMenuView = _uiFactory.CreateMainMenu().GetComponent<MainMenuView>();
      
      _mainMenuController = new MainMenuController(_stateMachine, _mainMenuView);
      _mainMenuController.SubscribeToActions();
      _mainMenuController.SetBestTime(PlayerPrefs.GetInt(PlayerPrefsKeys.BestTime));
    }
  }
}