using UnityEngine;

namespace QuizGame.Data
{
  [CreateAssetMenu(menuName = "Create GameRules", fileName = "GameRules", order = 0)]
  public class GameRules : ScriptableObject
  {
    public int MaximumMistakes;
    public bool isRandomOrder;
    public QuizQuestion[] Questions;
  }
}
