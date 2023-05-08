using System;
using System.Collections.Generic;
using QuizGame.Data;
using QuizGame.UI.Views;

namespace QuizGame.Controllers
{
  public class QuizViewController
  {
    public event Action<Answer> AnswerClicked;
  
    private readonly QuizView _quizView;
    private List<AnswerView> _answerViews;
  
    public QuizViewController(QuizView quizView)
    {
      _quizView = quizView;
    }

    public void OnAnswerClicked(Answer answer) => 
      AnswerClicked?.Invoke(answer);

    public void SetupQuizView(QuizQuestion quizQuestion) => 
      _quizView.SetupView(quizQuestion, OnAnswerClicked);

    public void UpdateTimer(int seconds) => 
      _quizView.UpdateTimer(Extensions.TimeInSecondsToString(seconds));

    public void OnWrongAnswer()
    {
    
    }
  }
}