using System;
using QuizGame.Infrastructure.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame.UI.Views
{
    public class MainMenuView : MonoBehaviour, ICoroutineRunner
    {
        public event Action PlayClicked;
    
        public Button PlayButton;
        public TextMeshProUGUI BestTimeText;

        private void Awake()
        {
            PlayButton.onClick.AddListener(OnPLayClick);
        }

        private void OnPLayClick() => 
            PlayClicked?.Invoke();

        public void SetBestTime(string time)
        {
            BestTimeText.text = time;
        }
    }
}