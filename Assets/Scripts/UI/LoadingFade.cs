using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingFade : MonoBehaviour
{
    public Image FadeImage;
    public float FadeTime;

    public void Show()
    {
      ResetFade();
      
      FadeImage.DOFade(0, FadeTime);
    }

    private void ResetFade() => 
      FadeImage.DOFade(1, 0);
}
