using UnityEngine;

public class StaffofFayytSpawn : MonoBehaviour
{
  public GameObject item;
  AssetManager assets;

  private Transform player;

  private void Start()
  {
    this.player = GameObject.FindWithTag("Player").transform;
    this.assets = GameObject.Find("AssetManager").GetComponent<AssetManager>();
  }

  /// <summary>
  /// Removes staff from inventory and resets staff bool.
  /// </summary>
  public void SpawnDroppedItem()
  {
    this.assets.hasStaff = false;
    Vector2 playerPos = new Vector2(this.player.position.x, this.player.position.y + 3);
    Instantiate(this.item, playerPos, Quaternion.identity);
  }
}
