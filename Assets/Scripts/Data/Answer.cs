using System;
using UnityEngine;

namespace QuizGame.Data
{
  [Serializable]
  public class Answer
  {
    public bool isCorrect;
    [TextArea]
    public string AnswerText;
  }
}