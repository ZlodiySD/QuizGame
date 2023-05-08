using System;
using QuizGame.Data;
using QuizGame.Infrastructure.Services;
using ModestTree;
using UnityEngine;

namespace QuizGame.Logic
{
  public class GameLoopRunner
  {
    public event Action GameWined;
    public event Action GameLossed;
    public event Action GameStarted;
    public event Action<QuizQuestion> QuestionAsked;
    public event Action WrongAnswered;
  
    private readonly GameRules _gameRules;
    private readonly Timer _timer;

    private QuizQuestion _activeQuestion;

    private QuizQuestion[] _questionsPool;

    private int _mistakeCount;
  
    public GameLoopRunner(GameRules gameRules, Timer timer)
    {
      _gameRules = gameRules;
      _timer = timer;
    }


    public void StartNewGame()
    {
      _activeQuestion = null;
      _mistakeCount = 0;
    
      _questionsPool = _gameRules.Questions;
    
      if(_gameRules.isRandomOrder)
        _questionsPool.Shuffle();
    
      _timer.StartTimer();
    
      NextQuestion();
    }

    private void NextQuestion()
    {
      _activeQuestion = GetQuestionFromPool(_activeQuestion);
      if (!_activeQuestion)
      {
        GameWin();
        return;
      }
    
      QuestionAsked?.Invoke(_activeQuestion);
    }

    public void AnswerProceed(Answer answer)
    {
      bool isAnswerCorrect = CheckIsAnserCorrect(answer);
    
      if(isAnswerCorrect)
        NextQuestion();
      else
        MistakeMade();
    }

    private void MistakeMade()
    {
      _mistakeCount++;
    
      WrongAnswered?.Invoke();
    
      if (_mistakeCount >= _gameRules.MaximumMistakes)
        GameLose();
      else
        NextQuestion();
    }

    private bool CheckIsAnserCorrect(Answer answer) => 
      _activeQuestion.Answers.ContainsItem(answer) && answer.isCorrect;

    private void GameWin()
    {
      _timer.StopTimer();

      int currentTime = _timer.TimeInSeconds;
      if (PlayerPrefs.GetInt(PlayerPrefsKeys.BestTime) < currentTime)
        PlayerPrefs.SetInt(PlayerPrefsKeys.BestTime,  currentTime);
    
      GameWined?.Invoke();
    }

    private void GameLose()
    {
      _timer.StopTimer();
      GameLossed?.Invoke();
    }

    private QuizQuestion GetQuestionFromPool(QuizQuestion activeQuestion)
    {
      if (_activeQuestion == null)
      {
        return _questionsPool[0];
      }
      else
      {
        int currentIndex = _questionsPool.IndexOf(_activeQuestion);

        if (currentIndex >= _questionsPool.Length - 1)
          return null;
        else
          return _questionsPool[currentIndex + 1];
      }
    }
  }
}