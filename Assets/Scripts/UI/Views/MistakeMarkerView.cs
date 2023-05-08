using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace QuizGame.UI.Views
{
  public class MistakeMarkerView : MonoBehaviour
  {
    public Image Image;
  
    public void MistakeIdle() => 
      Image.DOColor(Color.black, 0);

    public void MistakeActive() => 
      Image.DOColor(Color.white, 0);
  }
}