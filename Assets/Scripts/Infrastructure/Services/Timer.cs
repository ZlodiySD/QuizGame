using System;
using System.Collections;
using UnityEngine;

namespace QuizGame.Infrastructure.Services
{
  public class Timer: IDisposable
  {
    public event Action<int> TimerChanged; 

    public int TimeInSeconds
    {
      get => _timeInSeconds;
      set
      {
        _timeInSeconds = value;
        TimerChanged?.Invoke(_timeInSeconds);
      }
    }

    private readonly ICoroutineRunner _coroutineRunner;
    private Coroutine _activeTimer;
  
    private int _timeInSeconds;
    private bool _isRunTimer;

    public Timer(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void StartTimer()
    {
      StopActiveTimer();

      _isRunTimer = true;
      _activeTimer = _coroutineRunner.StartCoroutine(RunTimer());
    }

    public int StopTimer()
    {
      StopActiveTimer();
    
      return TimeInSeconds;
    }
  
    public void Dispose() => 
      StopActiveTimer();

    private void StopActiveTimer()
    {
      if (_activeTimer != null)
        _coroutineRunner.StopCoroutine(_activeTimer);

      _isRunTimer = false;
    }

    private IEnumerator RunTimer()
    {
      TimeInSeconds = 0;
      while (_isRunTimer)
      {
        yield return new WaitForSeconds(1);
      
        TimeInSeconds++;
      }
    }
  }
}
