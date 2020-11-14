using UnityEngine;

public class LootSpawner : MonoBehaviour
{
  public GameObject healthPotion;
  public GameObject gold;
  public GameObject strengthPotion;
  public GameObject speedPotion;
  public GameObject apple;
  public GameObject bread;

  private int _randLoot;

  /// <summary>
  /// using random numbers, generate loot in a room (can generate nothing
  /// so that the game is not flooded with too much loot.)
  /// </summary>
  private void Awake()
  {
    this._randLoot = Random.Range(0, 12);
    switch (this._randLoot)
    {
      case 0:
        Instantiate(this.healthPotion, this.transform.position, Quaternion.identity);
        break;

      case 1:
        //intentionally left blank.
        break;

      case 2:
        Instantiate(this.gold, this.transform.position, Quaternion.identity);
        break;

      case 3:
        //intentionally left blank.
        break;

      case 4:
        Instantiate(this.strengthPotion, this.transform.position, Quaternion.identity);
        break;

      case 5:
        //intentionally left blank.
        break;

      case 6:
        Instantiate(this.speedPotion, this.transform.position, Quaternion.identity);
        break;

      case 7:
        //intentionally left blank.
        break;

      case 8:
        Instantiate(this.apple, this.transform.position, Quaternion.identity);
        break;

      case 9:
        break;

      case 10:
        Instantiate(this.bread, this.transform.position, Quaternion.identity);
        break;

      case 11:
        //intentionally left blank.
        break;

      case 12:
        //intentionally left blank.
        break;

      default:
        break;
    }
    Destroy(this.gameObject, 0.2f);
  }
}
