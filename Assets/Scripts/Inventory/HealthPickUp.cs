using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
  private GameObject target;

  private void Start()
  {
    this.target = GameObject.FindGameObjectWithTag("Player");
  }

  /// <summary>
  /// Play sound, give player health based on current upgrades.
  /// </summary>
  public void UseHealth()
  {
    SoundManager.PlaySound(SoundManager.Sound.drinkPotion);
    PlayerScript player = this.target.GetComponent<PlayerScript>();
    player.ChangeHealth(player.maxHealth);
    Destroy(this.gameObject, 0.1f);
  }
}
