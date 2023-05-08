using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame.UI.Views
{
  public class AnswerView: MonoBehaviour
  {
    public TextMeshProUGUI Text;
    public Button Button;

    public void SetupText(string answerText) => 
      Text.text = answerText;
  }
}