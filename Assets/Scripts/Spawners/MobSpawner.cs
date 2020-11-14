using UnityEngine;

public class MobSpawner : MonoBehaviour
{
  public GameObject cyclops;
  public GameObject francis;
  public GameObject troll;
  public GameObject salamander;
  private int _indexToSpawn;

  /// <summary>
  /// randomly selects an enemy to spawn.  (Includes empty switches to
  /// ensure not all rooms will have an enemy.
  /// </summary>
  private void Awake()
  {
    this._indexToSpawn = Random.Range(0, 6);

    switch (this._indexToSpawn)
    {
      case 0:
        Instantiate(this.cyclops, this.transform.position, Quaternion.identity);
        break;
      case 1:
        Instantiate(this.francis, this.transform.position, Quaternion.identity);
        break;
      case 2:
        Instantiate(this.troll, this.transform.position, Quaternion.identity);
        break;
      case 3:
        Instantiate(this.salamander, this.transform.position, Quaternion.identity);
        break;
      case 4:
        break;
      case 5:
        break;
      case 6:
        break;
      default:
        break;
    }
  }

}
