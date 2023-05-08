using System;
using System.Collections.Generic;

namespace QuizGame
{
  public static class Extensions
  {
    private static readonly Random Random = new Random();  

    public static void Shuffle<T>(this IList<T> list)  
    {  
      int n = list.Count;  
      while (n > 1) {  
        n--;  
        int k = Random.Next(n + 1);  
        (list[k], list[n]) = (list[n], list[k]);
      }  
    }
  
    public static string TimeInSecondsToString(int timeInSeconds)
    {
      TimeSpan t = TimeSpan.FromSeconds(timeInSeconds);
      string text = $"{t.Minutes:D2}:{t.Seconds:D2}";;
    
      return text;
    }
  }
}