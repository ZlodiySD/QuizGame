using System;
using System.Collections.Generic;
using QuizGame.Data;
using UnityEngine;

namespace QuizGame.UI.Views
{
  public class AnswerHolderView : MonoBehaviour
  {
    public Transform ButtonHolder;
    private IUIFactory _uiFactory;

    private List<AnswerView> _answerViews;

    public void Construct(IUIFactory uiFactory)
    {
      _uiFactory = uiFactory;
      _answerViews = new List<AnswerView>();
    }
  
    public void SetupView(Answer[] quizQuestionAnswers, Action<Answer> answerClicked)
    {
      CreateAnswersViews(quizQuestionAnswers.Length);
      ResetAnswersViews();

      for (var i = 0; i < quizQuestionAnswers.Length; i++)
      {
        Answer answer = quizQuestionAnswers[i];
        AnswerView answerView = _answerViews[i];
      
        answerView.gameObject.SetActive(true);
        answerView.SetupText(answer.AnswerText);
      
        answerView.Button.onClick.AddListener(() => answerClicked?.Invoke(answer));
      }
    }

    private void CreateAnswersViews(int answersCount)
    {
      int viewToCreateCount = answersCount - _answerViews.Count;

      if (viewToCreateCount <= 0) 
        return;
    
      for (int i = 0; i < viewToCreateCount; i++)
      {
        AnswerView answerView = _uiFactory.CreateAnswerView(ButtonHolder).GetComponent<AnswerView>();
        _answerViews.Add(answerView);
      }
    }

    private void ResetAnswersViews()
    {
      foreach (AnswerView answerView in _answerViews)
      {
        answerView.Button.onClick.RemoveAllListeners();
        answerView.gameObject.SetActive(false);
      }
    }
  }
}