using UnityEngine;

public class BreadPickUp : MonoBehaviour
{
  private GameObject target;

  private void Start()
  {
    this.target = GameObject.FindGameObjectWithTag("Player");
  }

  /// <summary>
  /// Play sound, give player health based on current upgrades.
  /// </summary>
  public void UseBread()
  {
    SoundManager.PlaySound(SoundManager.Sound.eatBread);
    PlayerScript player = this.target.GetComponent<PlayerScript>();
    player.ChangeHealth(player.breadHeal);
    Destroy(this.gameObject, 0.1f);
  }
}
