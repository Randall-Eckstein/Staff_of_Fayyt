using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPresser : MonoBehaviour
{
  /// <summary>
  /// loads the dungeon scene
  /// </summary>
  public void Play()
  {
    SceneManager.LoadScene("Dungeon");
  }

  /// <summary>
  /// loads the upgrades scene
  /// </summary>
  public void Upgrades()
  {
    SceneManager.LoadScene("Upgrades");
  }

}
