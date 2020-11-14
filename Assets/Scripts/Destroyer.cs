using UnityEngine;

public class Destroyer : MonoBehaviour
{

  /// <summary>
  /// Destroys a game object (in preparation for moving it to player inventory)
  /// </summary>
  /// <param name="other"></param>
  void OnTriggerEnter2D(Collider2D other)
  {
    Destroy(other.gameObject);

  }
}
