using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.UI.Views
{
  public class MistakeView : MonoBehaviour
  {
    public Transform Holder;
    private IUIFactory _uiFactory;

    private List<MistakeMarkerView> _markers;
    private int _lastMistakeIndex;

    public void Construct(IUIFactory uiFactory)
    {
      _uiFactory = uiFactory;
      _markers = new List<MistakeMarkerView>();
    }

    public void SetupMistakes(int maxCount)
    {
      for (int i = 0; i < maxCount; i++)
      {
        MistakeMarkerView markerView = _uiFactory.CreateMistakeMarker(Holder).GetComponent<MistakeMarkerView>();
        markerView.MistakeIdle();
        _markers.Add(markerView);
      }
    }

    public void OnMistakeMaded()
    {
      _markers[_lastMistakeIndex].MistakeActive();
      
      _lastMistakeIndex++;
    }
  }
}