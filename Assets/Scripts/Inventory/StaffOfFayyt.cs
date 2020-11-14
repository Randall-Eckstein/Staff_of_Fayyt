using UnityEngine;

public class StaffOfFayyt : MonoBehaviour
{
  AssetManager assets;

  /// <summary>
  /// Collects staff and makes the hasStaff bool true.
  /// </summary>
  /// <param name="collision"></param>
  private void OnTriggerEnter2D(Collider2D collision)
  {
    this.assets = GameObject.Find("AssetManager").GetComponent<AssetManager>();

    this.assets.hasStaff = true;

    Destroy(this.gameObject);
  }
}
