using UnityEngine;

namespace QuizGame.Infrastructure.Services
{
  public interface IAssetProvider
  {
    GameObject Instantiate(string path, Transform parent);
    GameObject Instantiate(string path);
  }
}