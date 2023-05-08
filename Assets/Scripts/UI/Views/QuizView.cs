using System;
using QuizGame.Data;
using TMPro;
using UnityEngine;

namespace QuizGame.UI.Views
{
  public class QuizView : MonoBehaviour
  {
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI TimerText;
    
    public AnswerHolderView AnswerHolderView;
    public MistakeView MistakeView;
    
    public void SetupView(QuizQuestion quizQuestion, Action<Answer> answerClicked)
    {
      QuestionText.text = quizQuestion.Question;

      AnswerHolderView.SetupView(quizQuestion.Answers, answerClicked);
    }
  
    public void UpdateTimer(string time)
    {
      TimerText.text = time;
    }
  }
}