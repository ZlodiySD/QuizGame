using QuizGame.Infrastructure.Services;
using UnityEngine;

namespace QuizGame.UI
{
  public class UIFactory : IUIFactory
  {
    private readonly IAssetProvider _assetProvider;

    private Transform _rootTransform;
  
    public UIFactory(IAssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load<GameObject>("UI/UIRoot");
      _rootTransform = Object.Instantiate(rootPrefab).transform;
    }

    public GameObject CreateMainMenu() =>
      _assetProvider.Instantiate("UI/MainMenu", _rootTransform);

    public GameObject CreateQuizView() => 
      _assetProvider.Instantiate("UI/QuizView", _rootTransform);

    public GameObject CreateAnswerView(Transform holder) => 
      _assetProvider.Instantiate("UI/AnswerView", holder);

    public GameObject CreateGameEndView() => 
      _assetProvider.Instantiate("UI/GameEndView",_rootTransform);

    public void DestroyUIRoot()
    {
      if (_rootTransform)
        Object.Destroy(_rootTransform.gameObject);
    }
  }
}