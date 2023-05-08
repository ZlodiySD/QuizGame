using System.Collections;
using UnityEngine;

namespace QuizGame.Infrastructure.Services
{
  //Interface for launching coroutines in non-monbeh classes
  public interface ICoroutineRunner
  {
    public Coroutine StartCoroutine(IEnumerator routine);

    public void StopCoroutine(Coroutine routine);
  }
}