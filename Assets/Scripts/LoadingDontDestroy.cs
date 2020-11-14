using System.Collections;
using UnityEngine;

public class LoadingDontDestroy : MonoBehaviour
{
  Canvas loading;
  Transform tf;
  GameObject stairs;
  PlayerScript playerScript;

  private void Awake()
  {
    GameObject[] objs = GameObject.FindGameObjectsWithTag("Loader");
    if (objs.Length > 1)
    {
      Destroy(this.gameObject);
    }
    DontDestroyOnLoad(this.gameObject);
  }
  private void Start()
  {
    this.loading = this.gameObject.GetComponent<Canvas>();
    this.loading.enabled = false;
    this.playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
  }

  /// <summary>
  /// Coroutine to play the loading screen for a period of time.
  /// This gives the random level generator time to work.
  /// </summary>
  /// <returns></returns>
  IEnumerator LoadtheLoadingScreen()
  {
    SoundManager.PlaySound(SoundManager.Sound.downstairs);
    this.loading.enabled = true;
    this.playerScript.enabled = false;
    yield return new WaitForSeconds(5.5f);
    this.loading.enabled = false;
    this.playerScript.enabled = true;
  }

  /// <summary>
  /// Calls the loading screen
  /// </summary>
  public void GetGoing()
  {
    this.StartCoroutine(this.LoadtheLoadingScreen());
  }

  /// <summary>
  /// Moves player to the stairs location
  /// </summary>
  public void MoveToStairs()
  {
    this.StartCoroutine(this.FindStairs());
  }

  /// <summary>
  /// Coroutine to add time to allow several things to happen:
  /// first, the scene needs to change,
  /// second the sound will be played of walking up stairs.
  /// third, the random floor generator will have finished generating.
  /// fourth, find the stairs and move player to that place.
  /// </summary>
  /// <returns></returns>
  IEnumerator FindStairs()
  {
    yield return new WaitForSeconds(.5f);
    SoundManager.PlaySound(SoundManager.Sound.upstairs);
    yield return new WaitForSeconds(4.5f);
    this.tf = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    this.stairs = GameObject.FindGameObjectWithTag("Stairs");
    Vector3 location = this.stairs.transform.position;
    Vector3 moveplayer = new Vector3(location.x + 2, location.y + 2, location.z);
    this.tf.position = moveplayer;
  }

}
