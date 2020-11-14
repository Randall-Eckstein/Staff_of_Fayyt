using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

  public GameObject[] bottomRooms;
  public GameObject[] topRooms;
  public GameObject[] leftRooms;
  public GameObject[] rightRooms;

  public GameObject closedRoom;

  public List<GameObject> rooms;

  public float waitTime;
  private bool spawnedStairsDown;
  public GameObject stairsDown;
  private GameObject player;

  private void Awake()
  {
    this.player = GameObject.Find("Player");

    this.player.transform.position = Vector3.zero;
    SpriteRenderer sprite = this.player.GetComponent<SpriteRenderer>();
    sprite.enabled = true;
  }

  /// <summary>
  /// checks if stairs down have been set, and if timer has time left.
  /// If both are false, spawns the stairs down.
  /// </summary>
  void Update()
  {
    if (this.waitTime <= 0 && this.spawnedStairsDown == false)
    {
      for (int i = 0; i < this.rooms.Count; i++)
      {
        if (i == this.rooms.Count - 1)
        {
          Vector3 bossPlacement = new Vector3(this.rooms[i].transform.position.x, this.rooms[i].transform.position.y, 1);
          Instantiate(this.stairsDown, bossPlacement, Quaternion.identity);
          this.spawnedStairsDown = true;
        }
      }
    }
    else
    {
      this.waitTime -= Time.deltaTime;
    }
  }
}
