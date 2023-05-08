using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame.UI.Views
{
  public class GameEndView : MonoBehaviour
  {
    public event Action MainMenuClicked;
  
    public Button MainMenuButton;
    public TextMeshProUGUI GameEndText;

    public void Awake()
    {
      MainMenuButton.onClick.AddListener(() => MainMenuClicked?.Invoke());
    }

    public void SetText(string text) => 
      GameEndText.text = text;
  }
}
