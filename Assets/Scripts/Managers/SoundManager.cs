using UnityEngine;

public static class SoundManager
{

  /// <summary>
  /// collection of sounds able to be played.
  /// </summary>
  public enum Sound
  {
    backgroundMusic,
    hit,
    drinkPotion,
    eatBread,
    eatApple,
    die,
    walk,
    win,
    gold,
    downstairs,
    upstairs,
    staff
  }

  /// <summary>
  /// method to play a sound.
  /// </summary>
  /// <param name="sound"></param>
  public static void PlaySound(Sound sound)
  {
    GameObject soundGameObject = new GameObject("Sound");
    soundGameObject.transform.tag = "Sound";
    AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
    audioSource.PlayOneShot(GetAudioClip(sound));
  }

  /// <summary>
  /// Methot to return a sound clip.
  /// </summary>
  /// <param name="sound"></param>
  /// <returns>A sound to play</returns>
  private static AudioClip GetAudioClip(Sound sound)
  {
    foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
    {
      if (soundAudioClip.sound == sound)
      {
        return soundAudioClip.audioClip;
      }
    }
    Debug.LogError("Sound " + sound + " not found in system.");
    return null;
  }

}
