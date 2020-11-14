using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTravelUp : MonoBehaviour
{
  Scene scene;
  AssetManager assets;
  LoadingDontDestroy load;

  /// <summary>
  /// check if the player hit the stairs.
  /// If so, call the loading canvas, and change scene.
  /// 
  /// Additionally, if moving from first floor to main menu,
  /// checks if player has the staff, and if so, initalizes the win protocol.
  /// </summary>
  /// <param name="collision"></param>
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.name == "Player")
    {
      this.scene = SceneManager.GetActiveScene();
      this.assets = GameObject.Find("AssetManager").GetComponent<AssetManager>();
      this.load = GameObject.Find("Loader").GetComponent<LoadingDontDestroy>();

      switch (this.scene.name)
      {
        case "Dungeon":
          if (this.assets.hasStaff == false)
          {
            this.assets.MainMenu();
          }
          else
          {
            SoundManager.PlaySound(SoundManager.Sound.win);
            this.assets.Win();
          }
          break;
        case "2ndLevel":
          this.load.GetGoing();
          SoundManager.PlaySound(SoundManager.Sound.upstairs);
          SceneManager.LoadScene("Dungeon");
          break;
        case "3rdLevel":
          this.load.GetGoing();
          SoundManager.PlaySound(SoundManager.Sound.upstairs);
          SceneManager.LoadScene("2ndLevel");
          break;
        default:
          break;
      }
      if ((this.scene.name == "2ndLevel") || (this.scene.name == "3rdLevel"))
      {
        this.load.MoveToStairs();
      }
    }
  }
}
