using UnityEngine;

public class GameAssets : MonoBehaviour
{
  private static GameAssets _i;

  public static GameAssets i
  {
    get
    {
      if (_i == null)
      {
        _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
        Debug.Log("GameAssets was null.");
      }
      return _i;
    }
  }

  private void Awake()
  {
    _i = this;
  }

  public SoundAudioClip[] soundAudioClipArray;
  
  /// <summary>
  /// defines sound clips.
  /// </summary>
  [System.Serializable]
  public class SoundAudioClip
  {
    public SoundManager.Sound sound;
    public AudioClip audioClip;
  }


}
