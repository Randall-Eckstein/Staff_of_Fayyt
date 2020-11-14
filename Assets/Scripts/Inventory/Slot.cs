using UnityEngine;

public class Slot : MonoBehaviour
{
  private Inventory inventory;
  public int i;

  private void Start()
  {
    this.inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
  }

  /// <summary>
  /// determines if inventory is available
  /// </summary>
  private void Update()
  {
    if (this.transform.childCount <= 0)
    {
      this.inventory.isfull[this.i] = false;
    }
  }

  /// <summary>
  /// Removes item from inventory and sends it to a spawner.
  /// Then destroys this item.
  /// </summary>
  public void DropItem()
  {
    foreach (Transform child in this.transform)
    {
      child.GetComponent<Spawn>().SpawnDroppedItem();
      GameObject.Destroy(child.gameObject);
    }
  }
}
