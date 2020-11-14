using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
  private GoldDontDestroy _goldReference;

  private void Start()
  {
    this._goldReference = GameObject.Find("Gold Canvas").GetComponent<GoldDontDestroy>();
  }

  /// <summary>
  /// Creates a random amount of gold, and adds it to player inventory.
  /// </summary>
  /// <param name="other"></param>
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      SoundManager.PlaySound(SoundManager.Sound.gold);
      int rand = Random.Range(2, 8);
      this._goldReference.ChangeGoldDisplay(rand);
      Destroy(this.gameObject);
    }
  }
}
