using UnityEngine;

public class PickUp : MonoBehaviour
{
  private Inventory inventory;
  public GameObject itemButton;

  private void Start()
  {
    this.inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
  }

  /// <summary>
  /// moves game object from room to player inventory
  /// (if inventory is not full.)
  /// </summary>
  /// <param name="other"></param>
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      for (int i = 0; i < this.inventory.slots.Length; i++)
      {
        if (this.inventory.isfull[i] == false)
        {
          // Add item to inventory
          this.inventory.isfull[i] = true;
          Instantiate(this.itemButton, this.inventory.slots[i].transform, false);
          Destroy(this.gameObject);
          break;
        }
      }
    }
  }
}
