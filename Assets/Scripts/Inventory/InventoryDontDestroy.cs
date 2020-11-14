using UnityEngine;

public class InventoryDontDestroy : MonoBehaviour
{
  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("Inventory");
    if (objs.Length > 1)
    {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }
}
