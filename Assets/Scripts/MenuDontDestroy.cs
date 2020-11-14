using UnityEngine;

public class MenuDontDestroy : MonoBehaviour
{
  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("Menu");
    if (objs.Length > 1)
    {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }
}
