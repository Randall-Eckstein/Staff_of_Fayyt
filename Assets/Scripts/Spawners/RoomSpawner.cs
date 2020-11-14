using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

  public int openingDirection;
  // 1 --> need bottom door
  // 2 --> need top door
  // 3 --> need left door
  // 4 --> need right door


  private RoomTemplates templates;
  private int rand;
  public bool spawned = false;

  public float waitTime = 4f;

  /// <summary>
  /// Make sure this game object is destroyed after a period of time so that
  /// it doesn't continue taking resources.
  /// </summary>
  void Start()
  {
    Destroy(this.gameObject, this.waitTime);
    this.templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    this.Invoke("Spawn", 0.1f);
  }

  /// <summary>
  /// Checks if any other rooms are spawned in this location,
  /// then checks which direction to open the door in.
  /// </summary>
  void Spawn()
  {
    if (this.spawned == false)
    {
      if (this.openingDirection == 1)
      {
        // Need to spawn a room with a BOTTOM door.
        this.rand = Random.Range(0, this.templates.bottomRooms.Length);
        GameObject room1 = Instantiate(this.templates.bottomRooms[this.rand], this.transform.position, this.templates.bottomRooms[this.rand].transform.rotation);
      }
      else if (this.openingDirection == 2)
      {
        // Need to spawn a room with a TOP door.
        this.rand = Random.Range(0, this.templates.topRooms.Length);
        GameObject room2 = Instantiate(this.templates.topRooms[this.rand], this.transform.position, this.templates.topRooms[this.rand].transform.rotation);
      }
      else if (this.openingDirection == 3)
      {
        // Need to spawn a room with a LEFT door.
        this.rand = Random.Range(0, this.templates.leftRooms.Length);
        GameObject room3 = Instantiate(this.templates.leftRooms[this.rand], this.transform.position, this.templates.leftRooms[this.rand].transform.rotation);
      }
      else if (this.openingDirection == 4)
      {
        // Need to spawn a room with a RIGHT door.
        this.rand = Random.Range(0, this.templates.rightRooms.Length);
        GameObject room4 = Instantiate(this.templates.rightRooms[this.rand], this.transform.position, this.templates.rightRooms[this.rand].transform.rotation);
      }
      this.spawned = true;
    }
  }

  /// <summary>
  /// If another room tries to spawn in this room's space, checks and handles
  /// that scenario.
  /// </summary>
  /// <param name="other"></param>
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("SpawnPoint"))
    {
      if (other.GetComponent<RoomSpawner>().spawned == false && this.spawned == false)
      {
        Instantiate(this.templates.closedRoom, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
      }
      this.spawned = true;
    }
  }
}
