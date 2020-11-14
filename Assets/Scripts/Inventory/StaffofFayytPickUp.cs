using UnityEngine;

public class StaffofFayytPickUp : MonoBehaviour
{
  private Inventory inventory;
  public GameObject itemButton;
  AssetManager assets;

  private void Start()
  {
    this.inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    this.assets = GameObject.Find("AssetManager").GetComponent<AssetManager>();
  }

  /// <summary>
  /// Ensures only player can collect staff.
  /// Adds staff to inventory if not full.
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

          SoundManager.PlaySound(SoundManager.Sound.staff);
          this.assets.hasStaff = true;

          Destroy(this.gameObject);
          break;
        }
      }
    }
  }
}

