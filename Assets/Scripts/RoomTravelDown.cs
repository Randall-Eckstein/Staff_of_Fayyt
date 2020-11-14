using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTravelDown : MonoBehaviour
{
  Scene scene;
  LoadingDontDestroy load;

  /// <summary>
  /// check if the player hit the stairs.
  /// If so, call the loading canvas, and change scene.
  /// </summary>
  /// <param name="collision"></param>
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.name == "Player")
    {
      this.scene = SceneManager.GetActiveScene();
      this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();

      switch (this.scene.name)
      {
        case "Dungeon":
          this.load.GetGoing();
          SoundManager.PlaySound(SoundManager.Sound.downstairs);
          SceneManager.LoadScene("2ndLevel");

          break;
        case "2ndLevel":
          this.load.GetGoing();
          SoundManager.PlaySound(SoundManager.Sound.downstairs);
          SceneManager.LoadScene("3rdLevel");
          break;
        default:
          break;
      }

    }
  }

}
