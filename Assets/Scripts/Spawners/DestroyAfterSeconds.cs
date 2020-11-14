using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
  private void Awake()
  {
    Destroy(this.gameObject, 0.5f);
  }
}
