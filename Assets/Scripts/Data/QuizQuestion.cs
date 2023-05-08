using UnityEngine;

namespace QuizGame.Data
{
  [CreateAssetMenu(menuName = "Create QuizQuestionData", fileName = "QuizQuestionData", order = 0)]
  public class QuizQuestion : ScriptableObject
  {
    [TextArea(3,10)]
    public string Question;
    public Answer[] Answers;
  }
}