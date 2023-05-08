using UnityEngine;

namespace QuizGame.Infrastructure.Services
{
  public class AssetProvider : IAssetProvider
  {
    public GameObject Instantiate(string path, Transform parent)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, parent);
    }

    public GameObject Instantiate(string path)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab);
    }
  }
}