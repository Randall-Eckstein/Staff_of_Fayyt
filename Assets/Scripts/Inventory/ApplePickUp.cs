using UnityEngine;

public class ApplePickUp : MonoBehaviour
{
  private GameObject target;

  private void Start()
  {
    this.target = GameObject.FindGameObjectWithTag("Player");
  }

  /// <summary>
  /// Play sound, give player health and defense based on current upgrades.
  /// </summary>
  public void UseApple()
  {
    SoundManager.PlaySound(SoundManager.Sound.eatApple);
    PlayerScript player = this.target.GetComponent<PlayerScript>();
    player.ChangeHealth(player.appleHeal);
    player.ChangeDefense(15, player.appleDefense);
    Destroy(this.gameObject, 0.1f);
  }
}
