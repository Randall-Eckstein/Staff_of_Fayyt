using UnityEngine;

public class AddRoom : MonoBehaviour
{

  private RoomTemplates templates;

  /// <summary>
  /// Adds rooms to an array.
  /// </summary>
  void Start()
  {

    this.templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
    this.templates.rooms.Add(this.gameObject);
  }
}
