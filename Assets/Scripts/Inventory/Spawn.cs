using UnityEngine;

public class Spawn : MonoBehaviour
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
  /// Spawns an item in a room which was previously removed from a players
  /// inventory.  If it is the staff, will also reset the bool of having
  /// the staff.
  /// </summary>
  public void SpawnDroppedItem()
  {
    Vector2 playerPos = new Vector2(this.player.position.x, this.player.position.y + 3);
    Instantiate(this.item, playerPos, Quaternion.identity);
    if (this.item.name == "StaffOfFayyt")
    {
      this.assets.hasStaff = false;
    }
  }
}
