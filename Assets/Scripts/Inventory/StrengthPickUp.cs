using UnityEngine;

public class StrengthPickUp : MonoBehaviour
{
  private GameObject target;

  private void Start()
  {
    this.target = GameObject.FindGameObjectWithTag("Player");
  }

  /// <summary>
  /// Play sound, increase player strength based on current upgrades.
  /// </summary>
  public void IncreaseStrength()
  {
    SoundManager.PlaySound(SoundManager.Sound.drinkPotion);
    PlayerScript player = this.target.GetComponent<PlayerScript>();
    player.ChangeStrength(player.potionDuration, player.attackPotion);
    Destroy(this.gameObject, 0.1f);
  }
}
