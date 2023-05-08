using QuizGame.Infrastructure;
using UnityEngine;

namespace QuizGame.UI
{
  public interface IUIFactory
  {
    void CreateUIRoot();
  
    GameObject CreateMainMenu();
    GameObject CreateQuizView();
    GameObject CreateAnswerView(Transform holder);
    void DestroyUIRoot();
    GameObject CreateGameEndView();
    GameObject CreateMistakeMarker(Transform holder);
  }
}