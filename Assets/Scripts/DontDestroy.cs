using UnityEngine;

public class DontDestroy : MonoBehaviour
{
  /// <summary>
  /// Keeps an object in memory through scene changes.
  /// </summary>
  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");
    if (objs.Length > 1)
    {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }
}
