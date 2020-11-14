using UnityEngine;

public class DefensePickUp : MonoBehaviour
{
  private GameObject target;

  private void Start()
  {
    this.target = GameObject.FindGameObjectWithTag("Player");
  }

  /// <summary>
  /// Play sound, increase player defense based on current upgrades.
  /// </summary>
  public void IncreaseDefense()
  {
    SoundManager.PlaySound(SoundManager.Sound.drinkPotion);
    PlayerScript player = this.target.GetComponent<PlayerScript>();
    player.ChangeDefense(player.potionDuration, player.defensePotion);
    Destroy(this.gameObject, 0.1f);
  }
}
